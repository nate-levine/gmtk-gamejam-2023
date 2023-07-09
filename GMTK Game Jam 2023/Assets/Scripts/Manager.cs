using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public float transTime;
    public bool reloadText;

    public bool title;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Start()
    {
        reloadText = true;
        transTime = 1.0f;

        title = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (title)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                title = false;

                TitleImage.Instance.fadeAway = true;
                ReviewButton.Instance.SlideIn();
            }
        }
        if (!title)
        {
            if (Input.GetKeyDown(KeyCode.Return) && transTime == 2.0f && MadLibs.Instance.CheckFilled())
            {
                transTime = 0.0f;
                reloadText = true;

                ReviewButton.Instance.PressAnimation();
            }
            if (transTime > 1.0f && reloadText)
            {
                transform.GetChild(0).GetComponent<AudioSource>().Play();
                MadLibs.Instance.RunTransition();
                reloadText = false;

                Mark.Instance.canChange = true;
            }
            else if (transTime < 2.0f)
            {
                transTime += 1.0f * Time.deltaTime;
            }
            else if (transTime > 2.0f)
            {
                transTime = 2.0f;
            }
            if (Input.GetKeyDown(KeyCode.Return) && transTime == 2.0f && !MadLibs.Instance.CheckFilled())
            {
                ReviewButton.Instance.StopAnimation();
            }
        }
    }
}
