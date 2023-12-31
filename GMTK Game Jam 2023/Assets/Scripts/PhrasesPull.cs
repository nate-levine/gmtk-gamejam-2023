using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhrasesPull : MonoBehaviour
{
    public List<string> rating = new List<string>
    {
        "Rating 5.",
        "Rating 4.",
        "Rating 3.",
        "Rating 2.",
        "Rating 1.",
    };
    public List<string> start = new List<string>
    {
        "Testing A.",
        "Testing`(noun)`B.",
        "Testing C.",
    };
    public List<string> end = new List<string>
    {
        "Testing`(noun)*(noun)`.",
        "Testing`(noun)`.",
        "Testing F.",
    };

    public static PhrasesPull Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public string GetRating(int index)
    {
        return rating[index];
    }
    public string GetStart(int index)
    {
        return start[index];
    }
    public string GetEnd(int index)
    {
        return end[index];
    }
}
