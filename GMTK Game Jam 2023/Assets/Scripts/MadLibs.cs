using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MadLibs : MonoBehaviour
{
    public static MadLibs Instance { get; private set; }

    public GameObject staticTextPrefab;
    public GameObject dynamicTextPrefab;
    [SerializeField] string phrase;

    public int maximumNumberOfLines;
    public float lineWidth;
    public float lineSpacing;
    public float wordSpacing;

    [SerializeField] List<string> texts;
    [SerializeField] List<int> types;
    [SerializeField] float canvasWidth;
    [SerializeField] float canvasHeight;

    PhrasesPull phrasesPull;

    private float offsetSum;
    private float lineTotal;
    private int breakIndex;

    [SerializeField] bool textInitialized;

    private bool waitFrame;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        waitFrame = false;
        canvasWidth = transform.parent.GetComponent<RectTransform>().sizeDelta.x;
        canvasHeight = transform.parent.GetComponent<RectTransform>().sizeDelta.y;

        phrasesPull = PhrasesPull.Instance;

        textInitialized = false;
        PullPhrases();
        GenerateText();
        textInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (textInitialized)
        {
            breakIndex = 0;
            int lineIndex = 0;

            for (int i = 0; i < maximumNumberOfLines; i++)
            {
                if (breakIndex < types.Count)
                {
                    breakIndex = FormatLine(lineIndex);
                    lineIndex++;
                }
            }
        }

        if (waitFrame)
        {
            GenerateText();
            waitFrame = false;
        }
    }

    public void RunTransition()
    {
        textInitialized = false;
        PushPhrases();
        DeleteText();
        PullPhrases();
        waitFrame = true;
        textInitialized = true;
    }

    public bool CheckFilled()
    {
        bool filled = true;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<TMP_InputField>())
            {
                if (transform.GetChild(i).GetComponent<TMP_InputField>().text == "")
                {
                    transform.GetChild(i).GetComponent<InputField>().StopAnimation();

                    filled = false;
                }
            }
        }

        return filled;
    }

    public void PullPhrases()
    {
        int startIndex = UnityEngine.Random.Range(0, phrasesPull.start.Count);
        int midIndex = UnityEngine.Random.Range(0, phrasesPull.mid.Count);
        int endIndex = UnityEngine.Random.Range(0, phrasesPull.end.Count);

        phrase = phrasesPull.GetStart(startIndex) + " " + phrasesPull.GetMid(midIndex) + " " + phrasesPull.GetEnd(endIndex);
    }

    public void GenerateText()
    {
        SplitString();

        for (int i = 0; i < texts.Count; i++)
        {

            if (types[i] == 0)
            {
                GameObject newStaticText = Instantiate(staticTextPrefab, new Vector3(10000.0f, 10000.0f, 0), Quaternion.identity);
                newStaticText.name = "Static Text " + i.ToString();
                newStaticText.transform.SetParent(transform);

                transform.GetChild(i).GetComponent<TMP_Text>().text = texts[i];
            }
            else if (types[i] == 1)
            {
                GameObject newDynamicText = Instantiate(dynamicTextPrefab, new Vector3(10000.0f, 10000.0f, 0), Quaternion.identity);
                newDynamicText.name = "Editable Text " + i.ToString();
                newDynamicText.transform.SetParent(transform);

                transform.GetChild(i).transform.GetChild(0).transform.GetChild(1).GetComponent<TMP_Text>().text = texts[i];
            }
        }
    }

    public void DeleteText()
    {
        phrase = null;
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        texts.Clear();
        types.Clear();
    }

    public void PushPhrases()
    {
        string pushPhrase = "";

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == transform.childCount - 2)
            {
                if (transform.GetChild(i).GetComponent<TMP_Text>())
                {
                    pushPhrase += transform.GetChild(i).GetComponent<TMP_Text>().text + " ";
                }
                else if (transform.GetChild(i).GetComponent<TMP_InputField>())
                {
                    pushPhrase += transform.GetChild(i).GetComponent<TMP_InputField>().text;
                }
            }
            else if (transform.GetChild(i).GetComponent<TMP_Text>())
            {
                pushPhrase += transform.GetChild(i).GetComponent<TMP_Text>().text + " ";
            }
            else if (transform.GetChild(i).GetComponent<TMP_InputField>())
            {
                pushPhrase += transform.GetChild(i).GetComponent<TMP_InputField>().text + " ";
            }
        }

        PullPhrases();
    }

    public void SplitString()
    {
        string[] separatingStrings = { " ", "`", "*" };
        string[] words = phrase.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
        texts.AddRange(words);

        List<string> splitChars = new List<string>();

        // Modified. Credit: GSerg, StackOverflow
        int accumulatedLength = 0;
        foreach (string word in words)
        {
            accumulatedLength += word.Length + 1;
            if (accumulatedLength <= phrase.Length)
            {
                splitChars.Add(phrase[accumulatedLength - 1].ToString());
            }
        }
        //

        int type = 0;
        for (int i = 0; i < texts.Count; i++)
        {
            types.Add(type);

            if (i < texts.Count - 1)
            {
                if (type == 0 && splitChars[i] == " ")
                {
                    type = 0;
                }
                else if (type == 0 && splitChars[i] == "`")
                {
                    type = 1;
                }
                else if (type == 1 && splitChars[i] == "`")
                {
                    type = 0;
                }
                else if (type == 1 && splitChars[i] == "*")
                {
                    type = 1;
                }
            }
        }
    }

    public float TransitionFunc(float x)
    {
        if (x <= 1.0f)
        {
            return ((-x + 0.0f) * 2000.0f);
        }
        else if (x < 2.0f)
        {
            return ((-x + 2.0f) * 2000.0f);
        }
        else
        {
            return ((-x + 2.0f) * 2000.0f);
        }
    }

    public int FormatLine(int lineIndex)
    {
        offsetSum = 0.0f;
        lineTotal = 0.0f;

        for (int i = breakIndex; i < texts.Count; i++)
        {
            if (lineTotal < lineWidth)
            {
                lineTotal += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x + wordSpacing;

                if (lineTotal >= lineWidth)
                {
                    lineTotal -= transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x + wordSpacing;
                }
            }
        }

        for (int i = breakIndex; i < texts.Count; i++)
        {
            if (types[i] == 0)
            {
                FormatStaticText(i, lineIndex);
            }
            if (types[i] == 1)
            {
                FormatDynamicText(i, lineIndex);
            }

            offsetSum += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x + wordSpacing;

            if (offsetSum > lineWidth)
            {
                return i;
            }
        }

        return texts.Count;
    }

    public void FormatStaticText(int i, int lineIndex)
    {
        transform.GetChild(i).GetComponent<RectTransform>().localPosition = transform.position + new Vector3(-(canvasWidth / 2) + (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2) - (lineTotal / 2), -(canvasHeight / 2), 0.0f) + new Vector3(offsetSum, lineIndex * -lineSpacing, 0.0f) + new Vector3(TransitionFunc(Manager.Instance.transTime), -140.0f, 0.0f);
    }

    public void FormatDynamicText(int i, int lineIndex)
    {
        transform.GetChild(i).GetComponent<LayoutElement>().minWidth = transform.GetChild(i).transform.GetChild(0).transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.x;
        transform.GetChild(i).GetComponent<RectTransform>().localPosition = transform.position + new Vector3(-(canvasWidth / 2) + (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2) - (lineTotal / 2), -(canvasHeight / 2), 0.0f) + new Vector3(offsetSum, lineIndex * -lineSpacing, 0.0f) + new Vector3(TransitionFunc(Manager.Instance.transTime), -140.0f, 0.0f);
    }
}
