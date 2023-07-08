using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public int reviewsLeft;
    public float holdBuffer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        holdBuffer = 0.0f;
    }
    void Update()
    {
        
    }
}
