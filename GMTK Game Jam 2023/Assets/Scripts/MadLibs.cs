using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
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
    PhrasesPush phrasesPush;

    private float offsetSum;
    private float lineTotal;
    private int breakIndex;

    [SerializeField] bool textInitialized;

    private bool waitFrame;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void RunMadLibs()
    {
        waitFrame = false;
        canvasWidth = GetComponent<RectTransform>().sizeDelta.x;
        canvasHeight = GetComponent<RectTransform>().sizeDelta.y;

        phrasesPull = PhrasesPull.Instance;
        phrasesPush = PhrasesPush.Instance;

        textInitialized = false;
        PullPhrases();
        GenerateText();
        textInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.state >= 1 && Manager.Instance.state <= 5)
        {
            if (textInitialized)
            {
                if (Input.anyKey)
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
            }

            if (waitFrame)
            {
                GenerateText();
                waitFrame = false;
            }
        }
    }

    public void Push()
    {
        if (Manager.Instance.reviewsLeft > 0)
        {
            textInitialized = false;
            PushPhrases();
            DeleteText();

            Manager.Instance.reviewsLeft--;

            if (Manager.Instance.reviewsLeft > 0)
            {
                PullPhrases();
                waitFrame = true;
                textInitialized = true;
            }
        }
    }

    public void PullPhrases()
    {
        int startIndex = UnityEngine.Random.Range(0, phrasesPull.start.Count);
        int endIndex = UnityEngine.Random.Range(0, phrasesPull.end.Count);

        phrase = phrasesPull.GetStart(startIndex) + " " + phrasesPull.GetEnd(endIndex);
    }

    public void GenerateText()
    {
        SplitString();

        for (int i = 0; i < texts.Count; i++)
        {

            if (types[i] == 0)
            {
                GameObject newStaticText = Instantiate(staticTextPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                newStaticText.name = "Static Text " + i.ToString();
                newStaticText.transform.SetParent(transform);

                transform.GetChild(i).GetComponent<TMP_Text>().text = texts[i];
            }
            else if (types[i] == 1)
            {
                GameObject newDynamicText = Instantiate(dynamicTextPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
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

        PhrasesPush.Instance.phrasesPush.Add(pushPhrase);

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
        transform.GetChild(i).GetComponent<RectTransform>().localPosition = Vector3.zero + new Vector3((transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2) - (lineTotal / 2), -(canvasHeight / 2), 0.0f) + new Vector3(offsetSum, lineIndex * -lineSpacing, 0.0f);
    }

    public void FormatDynamicText(int i, int lineIndex)
    {
        transform.GetChild(i).GetComponent<LayoutElement>().minWidth = transform.GetChild(i).transform.GetChild(0).transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.x;
        transform.GetChild(i).GetComponent<RectTransform>().localPosition = Vector3.zero + new Vector3((transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2) - (lineTotal / 2), -(canvasHeight / 2), 0.0f) + new Vector3(offsetSum, lineIndex * -lineSpacing, 0.0f);
    }
}
