using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhrasesPush : MonoBehaviour
{
    public static PhrasesPush Instance { get; private set; }

    public List<string> phrasesPush = new List<string>();
    public List<int> phraseIndices = new List<int>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        for (int i = 0; i < 5; i++)
        {
            phraseIndices.Add(0);
        }
    }

    public void AddRatings()
    {
        for (int i = 0; i < phrasesPush.Count; i++)
        {
            int markIndexInSlot = MarkManager.Instance.slots[i].GetComponent<ItemSlot>().markIndex;
            phraseIndices[markIndexInSlot] = i;
        }

        for (int i = 0; i < phrasesPush.Count; i++)
        {
            phrasesPush[i] = PhrasesPull.Instance.GetRating(phraseIndices[i]) + " " + phrasesPush[i];
        }
    }
}
