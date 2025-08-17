using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShootingCrystal : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float damagePerHit;

    [SerializeField] private Light2D light;

    private void Start()
    {
        player = null;
        light.intensity = 0.5f;
        gameInput.OnUseRockAction += GameInput_OnUseRockAction;
    }

    private void GameInput_OnUseRockAction(object sender, System.EventArgs e)
    {
        if (player == null)
            return;

        GameObject proj = Instantiate(projectile, this.transform.position, Quaternion.identity);

        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - this.transform.position).normalized;
        proj.GetComponent<Projectile>().SetDirection(direction);
        proj.GetComponent<Projectile>().SetDamage(damagePerHit);
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            player = collision.gameObject;
            light.intensity = 1.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player = null;
            light.intensity = 0.5f;
        }
    }
}
