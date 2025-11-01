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

    protected override void HandleDeath()
    {
        Destroy(this.gameObject);
        Instantiate(pickupObject, transform.position, Quaternion.identity);

    }
}
