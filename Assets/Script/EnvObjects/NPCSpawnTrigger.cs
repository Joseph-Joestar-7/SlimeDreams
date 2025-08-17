using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnTrigger : MonoBehaviour
{
    [SerializeField] private NPC npc;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        npc.transform.position = this.transform.position;

        npc.gameObject.SetActive(true);
        npc.AppearNPC();
        npc.Interact();

        gameObject.SetActive(false);
    }

}
