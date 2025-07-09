using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType { Lucidity, Coins }

public class StatComponent : MonoBehaviour
{
    [SerializeField] private int lucidity;
    [SerializeField] private int maxLucidity;
    [SerializeField] private int coins;
    public void IncreaseValue(StatType stat, int amount)
    {
        switch (stat)
        {
            case StatType.Lucidity:
                lucidity += amount;
                break;
            case StatType.Coins:
                coins += amount;
                break;
        }
        lucidity = Mathf.Clamp(lucidity, 0, 100);
        coins = Mathf.Max(0, coins);
    }

    private void Update()
    {
       
    }
}
