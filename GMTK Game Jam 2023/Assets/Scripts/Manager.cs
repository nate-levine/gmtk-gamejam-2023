using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public int state;

    public int reviewsLeft;
    public float holdBuffer;

    private bool runMadLibs = true;
    private bool runSort = true;
    private bool endSort = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        state = 0;
        holdBuffer = 0.0f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Manager.Instance.holdBuffer += 1.0f * Time.deltaTime;

            if (Manager.Instance.holdBuffer >= 1.0f)
            {
                Manager.Instance.holdBuffer = 0.0f;

                state++;

                if (state > 1 && state <= 6)
                {
                    MadLibs.Instance.Push();
                }
            }
        }
        else if (Manager.Instance.holdBuffer > 0)
        {
            Manager.Instance.holdBuffer -= 1.0f * Time.deltaTime;

            if (Manager.Instance.holdBuffer < 0.0f)
            {
                Manager.Instance.holdBuffer = 0.0f;
            }
        }

        if (state == 1)
        {
            if (runMadLibs)
            {
                MadLibs.Instance.GetComponent<MadLibs>().RunMadLibs();
                runMadLibs = false;
            }
        }
        if (state == 6)
        {
            if (runSort)
            {
                MarkManager.Instance.RunSort();
                runSort = false;
            }
        }
        if (state == 7)
        {
            if (endSort)
            {
                MarkManager.Instance.EndSort();
                endSort = false;
                PhrasesPush.Instance.AddRatings();
            }
        }
        if (state == 9)
        {
        }
    }
}
