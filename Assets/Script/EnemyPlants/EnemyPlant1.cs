using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlant1 : EnemyPlantBase
{
    public void ApplyAttackDamage()
    {
        if (player != null)
        {
            Debug.Log("Attack Called");
            player.GetComponent<StatComponent>().IncreaseValue(StatType.Lucidity, -10);
        }
    }
}
