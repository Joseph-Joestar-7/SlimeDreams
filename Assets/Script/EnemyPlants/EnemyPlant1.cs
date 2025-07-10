using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlant1 : EnemyPlantBase
{
    
    public void ApplyAttackDamage()
    {
        if (player != null)
        {
            player.GetComponent<StatComponent>().IncreaseValue(StatType.Lucidity, -(damageValue/2));
        }
    }
}
