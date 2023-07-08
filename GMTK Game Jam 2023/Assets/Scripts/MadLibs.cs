using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MadLibs : MonoBehaviour
{
    public GameObject staticTextPrefab;
    public GameObject dynamicTextPrefab;

    public List<string> texts;
    public List<int> types;

    public float canvasWidth;
    public float canvasHeight;

    public int maximumNumberOfLines;
    public float lineWidth;

    float offsetSum;
    float lineTotal;

    int breakIndex;


    void Start()
    {
        canvasWidth = GetComponent<RectTransform>().sizeDelta.x;
        canvasHeight = GetComponent<RectTransform>().sizeDelta.y;

        for (int i = 0; i < types.Count; i++)
        {
            if (types[i] == 0)
            {
                GameObject newStaticText = Instantiate(staticTextPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                newStaticText.name = "Static Text " + i.ToString();
                newStaticText.transform.SetParent(transform);

                transform.GetChild(i).GetComponent<TMP_Text>().text = texts[i];
            }
            if (types[i] == 1)
            {
                GameObject newDynamicText = Instantiate(dynamicTextPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                newDynamicText.name = "Editable Text " + i.ToString();
                newDynamicText.transform.SetParent(transform);

                transform.GetChild(i).transform.GetChild(0).transform.GetChild(1).GetComponent<TMP_Text>().text = texts[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
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

    public int FormatLine(int lineIndex)
    {
        offsetSum = 0.0f;
        lineTotal = 0.0f;

        for (int i = breakIndex; i < types.Count; i++)
        {
            if (lineTotal < lineWidth)
            {
                lineTotal += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x + 10;

                if (lineTotal >= lineWidth)
                {
                    lineTotal -= transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x + 10;
                }
            }
        }

        for (int i = breakIndex; i < types.Count; i++)
        {
            if (types[i] == 0)
            {
                FormatStaticText(i, lineIndex);
            }
            if (types[i] == 1)
            {
                FormatDynamicText(i, lineIndex);
            }

            offsetSum += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x + 10;

            if (offsetSum > lineWidth)
            {
                return i;
            }
        }

        return types.Count;
    }

    public void FormatStaticText(int i, int lineIndex)
    {
        transform.GetChild(i).GetComponent<RectTransform>().localPosition = transform.position + new Vector3(-(canvasWidth / 2) + (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2) - (lineTotal / 2), -(canvasHeight / 2), 0.0f) + new Vector3(offsetSum, lineIndex * -50.0f, 0.0f);
    }

    public void FormatDynamicText(int i, int lineIndex)
    {
        transform.GetChild(i).GetComponent<LayoutElement>().minWidth = transform.GetChild(i).transform.GetChild(0).transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.x;
        transform.GetChild(i).GetComponent<RectTransform>().localPosition = transform.position + new Vector3(-(canvasWidth / 2) + (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2) - (lineTotal / 2), -(canvasHeight / 2), 0.0f) + new Vector3(offsetSum, lineIndex * -50.0f, 0.0f);
    }
}
