using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlant2 : EnemyPlantBase
{
    [SerializeField] private PickUpObject pickupObject;
    private int goldTaken=0;
    public void ApplyAttackDamage()
    {
        if (damageAppliedThisAttack) return;  
        damageAppliedThisAttack = true;

        if (player != null)
        {
            player.GetComponent<StatComponent>().IncreaseValue(StatType.Lucidity,-damageValue);
            player.GetComponent<StatComponent>().IncreaseValue(StatType.Gold, -1);
            goldTaken++;
        }
    }

    public void SpawnPickup()
    {
        for (int i = 0; i < goldTaken-2; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0f);
            Instantiate(pickupObject, transform.position + offset, Quaternion.identity);
        }
    }

    protected override void HandleDeath()
    {
        base.HandleDeath();
        GetComponent<Collider2D>().enabled = false;
        animator.SetTrigger("Death");
        Destroy(gameObject, 1f);
    }
}
