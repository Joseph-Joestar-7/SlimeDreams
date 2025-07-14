using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            collision.GetComponent<StatComponent>().IncreaseValue(StatType.Coins, 1);
            Destroy(gameObject);
        }
    }
}
