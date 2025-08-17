using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 1f;
    public float lifetime = 2f; // auto-destroy after 2s
    private float dam;
    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    public void SetDamage(float damage)
    {
        dam = damage;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyPlantBase>())
        {
            collision.GetComponent<EnemyPlantBase>().OnDamage(dam);
            Destroy(gameObject);
        }
    }
}
