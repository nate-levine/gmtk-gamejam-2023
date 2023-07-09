using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewButton : MonoBehaviour
{
    public static ReviewButton Instance { get; private set; }

    bool down;
    float counter;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        down = false;
        counter = 0.0f;
    }

    public void PressAnimation()
    {
        down = true;
    }

    private void Update()
    {
        if (down)
        {
            counter += 6.0f * Time.deltaTime;

            if (counter > 0.0f & counter < 1.0f)
            {
                transform.position -= new Vector3(0.0f, 1.0f, 0.0f) * 20.0f * Time.deltaTime;
            }
            if (counter >= 1.0f && counter < 2.0f)
            {
                transform.position -= new Vector3(0.0f, -1.0f, 0.0f) * 20.0f * Time.deltaTime;
            }
            if (counter >= 2.0f)
            {
                down = false;
                counter = 0.0f;
            }
        }
    }
}
