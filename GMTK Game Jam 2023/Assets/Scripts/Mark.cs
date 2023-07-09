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

    public float chinOffset;
    public float eyeOffset;
    public float hairOffset;

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

        chinOffset = Random.Range(0.0f, 1.0f);
        eyeOffset = Random.Range(0.0f, 1.0f);
        hairOffset = Random.Range(0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canChange)
        {
            ChangeParts();
        }

        transform.position = new Vector3(400.0f, 100.0f, 100.0f) + new Vector3(TransitionFunc(Manager.Instance.transTime), 0.0f, 0.0f);


        chinOffset += Time.deltaTime;
        chins.transform.localPosition = new Vector3(0.02f * Mathf.Sin(chinOffset), 0.0f, 0.02f * Mathf.Cos(chinOffset));
        eyeOffset += Time.deltaTime;
        eyes.transform.localPosition = new Vector3(0.02f * Mathf.Sin(eyeOffset), 0.0f, 0.02f * Mathf.Cos(eyeOffset));
        hairOffset += Time.deltaTime;
        hairs.transform.localPosition = new Vector3(0.02f * Mathf.Sin(hairOffset), 0.0f, 0.02f * Mathf.Cos(hairOffset));
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

        int[] indices = new int[3];
        indices = GetComponent<MarkRarityAlgo>().Run();

        int chinIndex = indices[0];
        int eyeIndex =  indices[1];
        int hairIndex = indices[2];

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
