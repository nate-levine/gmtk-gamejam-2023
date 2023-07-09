using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PressEnter : MonoBehaviour
{
    public static PressEnter Instance { get; private set; }

    public float opacity;
    public float currOpacity;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        currOpacity = 0.0f;
    }

    void Update()
    {
        if (Manager.Instance.title)
        {
            opacity += Time.deltaTime;

            currOpacity = (1.0f - ((Mathf.Cos(opacity) + 1.0f) / 2.0f));

            GetComponent<TMP_Text>().color = new Color(1.0f, 1.0f, 1.0f, currOpacity);
        }
        else
        {
            if (currOpacity > 0.0f)
            {
                currOpacity -= Time.deltaTime;
            }

            GetComponent<TMP_Text>().color = new Color(1.0f, 1.0f, 1.0f, currOpacity);
        }
    }
}
