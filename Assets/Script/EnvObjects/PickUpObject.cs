using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    [SerializeField] private StatType pickUpType;
    [SerializeField] private int pickUpValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            collision.GetComponent<StatComponent>().IncreaseValue(pickUpType, pickUpValue);
            Destroy(gameObject);
        }
    }
}
