using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlant1 : EnemyPlantBase
{
    [SerializeField] private PickUpObject pickupObject;
    public void ApplyAttackDamage()
    {
        if (damageAppliedThisAttack) return;  // <--- prevents duplicate applications
        damageAppliedThisAttack = true;

        if (player != null)
        {
            player.GetComponent<StatComponent>().IncreaseValue(StatType.Lucidity, -damageValue);
        }
    }

    public void SpawnPickup()
    {
        if (pickupObject != null)
        {
            Instantiate(pickupObject, transform.position, Quaternion.identity);
        }
    }

    protected override void HandleDeath()
    {
        GetComponent<Collider2D>().enabled = false;
        animator.SetTrigger("Die");

        Destroy(gameObject, 1f);
    }
}
