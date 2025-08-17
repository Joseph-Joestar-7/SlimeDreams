using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum StatType { Lucidity, Gold }

public class StatComponent : MonoBehaviour
{
    [SerializeField] private int lucidity;
    [SerializeField] private int maxLucidity;
    [SerializeField] private int coins;

    [SerializeField] private Image lucidityBar;
    [SerializeField] private TMP_Text coinText;

    [SerializeField] private int lucidityDrainAmount = 5; // X
    [SerializeField] private float lucidityDrainInterval = 2f; // Y

    private float lucidityDrainTimer = 0f;

    private void Start()
    {
        UpdateUI();
    }
    public void IncreaseValue(StatType stat, int amount)
    {
        switch (stat)
        {
            case StatType.Lucidity:
                lucidity += amount;
                Debug.Log(lucidity);
                break;
            case StatType.Gold:
                coins += amount;
                break;
        }
        lucidity = Mathf.Clamp(lucidity, 0, 100);
        coins = Mathf.Max(0, coins);

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (lucidityBar != null)
            lucidityBar.fillAmount = (float)lucidity / maxLucidity;

        if (coinText != null)
            coinText.text = coins.ToString();
    }

    private void Update()
    {
        if (lucidity > 0)
        {
            lucidityDrainTimer += Time.deltaTime;

            if (lucidityDrainTimer >= lucidityDrainInterval)
            {
                lucidity -= lucidityDrainAmount;
                lucidity = Mathf.Clamp(lucidity, 0, maxLucidity);
                UpdateUI();

                lucidityDrainTimer = 0f;
            }
        }
    }
}
