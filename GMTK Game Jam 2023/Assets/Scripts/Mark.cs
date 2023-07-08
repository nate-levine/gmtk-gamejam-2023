using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    public static Mark Instance { get; private set; }

    public List<GameObject> chinTypes = new List<GameObject>();
    public List<GameObject> eyeTypes = new List<GameObject>();
    public List<GameObject> hairTypes = new List<GameObject>();

    private GameObject root;
    private GameObject chins;
    private GameObject eyes;
    private GameObject hairs;

    public bool canChange;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        root = transform.GetChild(0).transform.GetChild(0).gameObject;

        chins = root.transform.Find("Chins").gameObject;
        eyes = root.transform.Find("Eyes").gameObject;
        hairs = root.transform.Find("Hairs").gameObject;

        foreach (Transform child in chins.transform)
        {
            chinTypes.Add(child.gameObject);
        }
        foreach (Transform child in eyes.transform)
        {
            eyeTypes.Add(child.gameObject);
        }
        foreach (Transform child in hairs.transform)
        {
            hairTypes.Add(child.gameObject);
        }

        canChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canChange)
        {
            ChangeParts();
        }

        transform.position = new Vector3(400.0f, 70.0f, 100.0f) + new Vector3(TransitionFunc(Manager.Instance.transTime), 0.0f, 0.0f);
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

    public void ChangeParts()
    {
        canChange = false;

        int chinIndex = Random.Range(0, 5);
        int eyeIndex = Random.Range(0, 5);
        int hairIndex = Random.Range(0, 5);
        Debug.Log("changeParts");
        for (int i = 0; i < chinTypes.Count; i++)
        {
            if (i == chinIndex)
            {
                foreach (Transform child in chinTypes[i].transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            else
            {
                foreach (Transform child in chinTypes[i].transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
        for (int i = 0; i < eyeTypes.Count; i++)
        {
            if (i == eyeIndex)
            {
                foreach (Transform child in eyeTypes[i].transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            else
            {
                foreach (Transform child in eyeTypes[i].transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
        for (int i = 0; i< hairTypes.Count; i++)
        {
            if (i == hairIndex)
            {
                foreach (Transform child in hairTypes[i].transform)
                {
                child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            else
            {
                foreach (Transform child in hairTypes[i].transform)
                {
                    child.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }
}
