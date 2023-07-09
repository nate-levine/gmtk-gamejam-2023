using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleImage : MonoBehaviour
{
    public static TitleImage Instance { get; private set; }

    public bool fadeAway;

    public float rotate;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;    
    }

    void Start()
    {
        rotate = 0;
        fadeAway = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fadeAway)
        {
            rotate += Time.deltaTime;

            transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 1.0f * Time.deltaTime * Mathf.Sign(Mathf.Sin(rotate + (Mathf.PI/2))));
        }
        if (fadeAway)
        {
            transform.position += new Vector3(0.0f, 1200.0f, 0.0f) * Time.deltaTime;
        }
    }
}
