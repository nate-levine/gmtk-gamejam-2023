using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Hardware;
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
        if (range[0] + range[1] + range[2] >= 9)
        {
            combo = 2;
        }
        if (range[0] + range[1] + range[2] >= 15)
        {
            combo = 3; 
        }

        int randomIncrement = UnityEngine.Random.Range(0, 3);
        if (runs > 1)
        {
            if (range[randomIncrement] < 5)
            {
                if (runs < 10)
                {
                    range[randomIncrement] += 2;
                }
                if (runs >= 10)
                {
                    range[randomIncrement]++;
                }
            }
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
            if (cI == 0 && eI == 0 && hI == 0 && runs > 0)
            {
                for (int i = 0; i < pickedIndices.Count; i++)
                {
                    if (pickedIndices[i] == 0)
                    {
                        cI = UnityEngine.Random.Range(0, range[0]);
                    }
                    if (pickedIndices[i] == 1)
                    {
                        eI = UnityEngine.Random.Range(0, range[0]);
                    }
                    if (pickedIndices[i] == 2)
                    {
                        hI = UnityEngine.Random.Range(0, range[0]);
                    }
                }
            }
        }

        runs++;
        return new int[3] { cI, eI, hI };
    }
}
