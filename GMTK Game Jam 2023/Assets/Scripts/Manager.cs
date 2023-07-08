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
            MadLibs.Instance.GetComponent<MadLibs>().RunMadLibs();
        }
    }
}
