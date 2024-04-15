using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ProbabilitySystem
{
    private List<int> values = new List<int>();

    public ProbabilitySystem()
    {
        AddValue();
    }

    public void AddValue()
    {
        for (int i = 0; i < 100; i++)
        {
            values.Add(i);
        }
    }

    public int GetRandomValue()
    {
        if (values.Count == 0)
        {
            AddValue();
        }

        int randomIndex = Random.Range(0, values.Count);
        int result = values[randomIndex];
        values.RemoveAt(randomIndex);
        return result;
    }
}