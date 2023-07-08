using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhrasesPush : MonoBehaviour
{
    public static PhrasesPush Instance { get; private set; }

    public List<string> phrasesPush = new List<string>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
