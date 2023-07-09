using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floaty : MonoBehaviour
{
    public float intensityH;
    public float intensityV;
    public bool canvas;

    private float offset;
    void Start()
    {
        offset = Random.Range(0.0f, Mathf.PI * 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime;

        if (canvas)
        {
            transform.localPosition = new Vector3(intensityH * Mathf.Sin(offset), intensityV * Mathf.Cos(offset), transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(intensityH * Mathf.Sin(offset), transform.localPosition.y, intensityV * Mathf.Cos(offset));
        }
    }
}
