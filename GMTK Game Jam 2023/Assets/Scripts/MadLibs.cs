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

    float offsetSum;


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
        offsetSum = 0.0f;

        for (int i = 0; i < types.Count; i++)
        {
            if (types[i] == 0)
            {
                FormatStaticText(i);
            }
            if (types[i] == 1)
            {
                FormatDynamicText(i);
            }

            offsetSum += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x + 10;
        }
    }

    public void FormatStaticText(int i)
    {
        transform.GetChild(i).GetComponent<RectTransform>().localPosition = transform.position - new Vector3(canvasWidth / 2 - (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2), canvasHeight / 2, 0.0f) + new Vector3(offsetSum, 0.0f, 0.0f);
    }

    public void FormatDynamicText(int i)
    {
        transform.GetChild(i).GetComponent<LayoutElement>().minWidth = transform.GetChild(i).transform.GetChild(0).transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.x;
        transform.GetChild(i).GetComponent<RectTransform>().localPosition = transform.position - new Vector3(canvasWidth / 2 - (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2), canvasHeight / 2, 0.0f) + new Vector3(offsetSum, 0.0f, 0.0f);
    }
}
