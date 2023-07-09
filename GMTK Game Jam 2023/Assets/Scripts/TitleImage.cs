using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleImage : MonoBehaviour
{
    public static TitleImage Instance { get; private set; }

    public bool fadeAway;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;    
    }

    void Start()
    {
        fadeAway = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeAway)
        {
            transform.position += new Vector3(0.0f, 1200.0f, 0.0f) * Time.deltaTime;
        }
    }
}
