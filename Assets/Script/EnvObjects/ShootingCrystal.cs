using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCrystal : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject projectile;
    private void Start()
    {
        player = null;

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
        proj.GetComponent<Projectile>().SetDamage(10);
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player = null;
        }
    }
}
