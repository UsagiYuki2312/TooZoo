using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaObject : MonoBehaviour
{
    public int[] gatchaRange;
    public GachaBannerData gachaBannerData = new GachaBannerData();

    public GameObject[] gachaNormalData;
    public GameObject[] gachaSpecialData;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gachaNormalData = new GameObject[1];
            gachaNormalData = GetNormalGachaRewards(1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gachaSpecialData = new GameObject[1];
            gachaSpecialData = GetEpicGachaRewards(1);
        }
    }

    public int[] BuildGatchaRange(int type)
    {
        int index = Math.Clamp(type, 0, 3 - 1); //Get Type of gacha rate banner
        int[] rate = { 70, 24, 5 ,1};
        int[] range = new int[rate.Length];
        range[0] = rate[0];
        for (int i = 1; i < range.Length; i++) range[i] = rate[i] + range[i - 1];
        return range;
    }

    public int[] GetRewards(int type)
    {
        int index = Math.Clamp(type, 0, 3);
        int[] rate = { 1, 2, 3, 4 };
        return rate;
    }

    public GameObject[] GetNormalGachaRewards(int amount)
    {
        gatchaRange = BuildGatchaRange(0);
        int[] reward = GetRewards(0);
        int[] tiers = new int[amount];
        GameObject[] gameObjectRewards = new GameObject[tiers.Length];

        for (int i = 0; i < tiers.Length; i++)
        {
            tiers[i] = PickReward(gatchaRange, reward);
            gameObjectRewards[i] = new GameObject("HEHE: " + i + " Tier: " + tiers[i]);
        }
        return gameObjectRewards;
    }

    public GameObject[] GetEpicGachaRewards(int amount)
    {
        gatchaRange = BuildGatchaRange(0);
        int[] reward = GetRewards(0);
        int[] tiers = new int[amount];
        GameObject[] gameObjectRewards = new GameObject[tiers.Length];
        for (int i = 0; i < tiers.Length; i++)
        {
            gachaBannerData.epicGachaOpenNumber++;
            tiers[i] = PickReward(gatchaRange, reward);
            tiers[i] = ValidateEpicChestTier(tiers[i]);
            gameObjectRewards[i] = new GameObject("HEHE: " + i + " Tier: " + tiers[i]);
        }

        return gameObjectRewards;
    }

    private int ValidateEpicChestTier(int tier)
    {
        if (gachaBannerData.epicGachaOpenNumber >= 10) tier = 4;
        if (tier == 4)
        {
            gachaBannerData.epicGachaOpenNumber = 0;
        }
        return tier;
    }

    private int PickReward(int[] gatchaRange, int[] reward)
    {
        int tier = reward[0];
        int index = UnityEngine.Random.Range(1, 101);
        for (int i = gatchaRange.Length - 2; i >= 0; i--)
        {
            if (index > gatchaRange[i])
            {
                tier = reward[i + 1];
                break;
            }
        }
        return tier;
    }
}

[System.Serializable]
public class GachaBannerData
{
    public int epicGachaOpenNumber;
    public int epicSGachaOpenNumber;
}
