using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlant2 : EnemyPlantBase
{
    public void ApplyAttackDamage()
    {
        if (damageAppliedThisAttack) return;  // <--- prevents duplicate applications
        damageAppliedThisAttack = true;

        if (player != null)
        {
            player.GetComponent<StatComponent>().IncreaseValue(StatType.Lucidity,-damageValue);
            player.GetComponent<StatComponent>().IncreaseValue(StatType.Gold, -1);
        }
    }
}
