using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBar : MonoBehaviour
{
    private float canvasWidth;

    void Start()
    {
        canvasWidth = transform.parent.GetComponent<RectTransform>().sizeDelta.x;
    }
    void Update()
    {
        GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, Mathf.SmoothStep(0, 1, Manager.Instance.holdBuffer));
        GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.SmoothStep(0, canvasWidth, Manager.Instance.holdBuffer), 10.0f);
    }
}
