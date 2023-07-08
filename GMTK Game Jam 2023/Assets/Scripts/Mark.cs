using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(480.0f, 230.0f, 0.0f) + new Vector3(TransitionFunc(Manager.Instance.transTime), 0.0f, 0.0f);
    }
    public float TransitionFunc(float x)
    {
        if (x <= 1.0f)
        {
            return ((x + 0.0f) * 1000.0f);
        }
        else if (x < 2.0f)
        {
            return ((x - 2.0f) * 1000.0f);
        }
        else
        {
            return ((x - 2.0f) * 1000.0f);
        }
    }
}
