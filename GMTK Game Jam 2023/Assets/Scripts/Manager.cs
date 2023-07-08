using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public float transTime;
    public bool reloadText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Start()
    {
        reloadText = true;
        transTime = 1.0f;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Return) && transTime == 2.0f && MadLibs.Instance.CheckFilled())
        {
            transTime = 0.0f;
            reloadText = true;

        }
        if (transTime > 1.0f && reloadText)
        {
            MadLibs.Instance.RunTransition();
            reloadText = false;
        }
        else if (transTime < 2.0f)
        {
            transTime += 1.0f * Time.deltaTime;
        }
        else if (transTime > 2.0f)
        {
            transTime = 2.0f;
        }
    }
}
