using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkRarityAlgo : MonoBehaviour
{
    int[] range;

    int runs;
    int combo;

    int cI;
    int eI;
    int hI;

    private void Start()
    {
        range = new int[3];
        range[0] = 1;
        range[1] = 1;
        range[2] = 1;

        runs = 0;

        combo = 1;
    }

    public int[] Run()
    {
        if (runs >= 10)
        {
            combo = 2;
        }
        if (runs >= 20)
        {
            combo = 3; 
        }

        List<int> choices = new List<int>() { 0, 1, 2 };
        List<int> pickedIndices = new List<int>();

        for (int i = 0; i < combo; i++)
        {
            int choiceIndex = UnityEngine.Random.Range(0, (3 - i));
            pickedIndices.Add(choices[choiceIndex]);
            choices.RemoveAt(choiceIndex);
        }

        cI = 0;
        eI = 0;
        hI = 0;

        for (int loop = 0; loop < 5; loop++)
        {
            if (runs == 1)
            {
                cI = 0;
                eI = 0;
                hI = 0;
            }
            if (cI == 0 && eI == 0 && hI == 0 && runs > 1)
            {
                for (int i = 0; i < pickedIndices.Count; i++)
                {
                    if (pickedIndices[i] == 0)
                    {
                        cI = UnityEngine.Random.Range(0, 5);
                    }
                    if (pickedIndices[i] == 1)
                    {
                        eI = UnityEngine.Random.Range(0, 5);
                    }
                    if (pickedIndices[i] == 2)
                    {
                        hI = UnityEngine.Random.Range(0, 5);
                    }
                }
            }
        }

        runs++;
        return new int[3] { cI, eI, hI };
    }
}
