using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum StatType { Lucidity, Coins }

public class StatComponent : MonoBehaviour
{
    [SerializeField] private int lucidity;
    [SerializeField] private int maxLucidity;
    [SerializeField] private int coins;

    [SerializeField] private Image lucidityBar;
    [SerializeField] private TMP_Text coinText;

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
            case StatType.Coins:
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
        
    }
}
