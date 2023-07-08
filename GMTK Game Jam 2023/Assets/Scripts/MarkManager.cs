using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkManager : MonoBehaviour
{
    public static MarkManager Instance;

    public GameObject markPrefab;
    public GameObject slotPrefab;

    public List<GameObject> marks = new List<GameObject>();
    public List<GameObject> slots = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void RunSort()
    {
        // slots
        for (int i = 0; i < 5; i++)
        {
            GameObject slot = Instantiate(slotPrefab, new Vector3(200 + (i * 120), 350, 0), Quaternion.identity);
            slot.name = "Slot " + i.ToString();
            slot.transform.SetParent(transform);

            slots.Add(slot);
        }

        // marks
        for (int i = 0; i < 5; i++)
        {
            GameObject mark = Instantiate(markPrefab, new Vector3(200 + (i * 120), 200, 0), Quaternion.identity);
            mark.name = "Mark " + i.ToString();
            mark.transform.SetParent(transform);
            mark.GetComponent<Mark>().SetIndex(i);
            mark.GetComponent<Image>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

            marks.Add(mark);
        }
    }
}
