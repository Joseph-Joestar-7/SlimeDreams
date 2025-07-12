using System;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireflyParticles;
    [SerializeField] private float cooldownDuration = 5f;

    private bool isCooling = false;
    private float cooldownTimer = 0f;

    private void Start()
    {
        if (fireflyParticles.isPlaying)
            fireflyParticles.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCooling && other.CompareTag("Player"))
        {
            fireflyParticles.Play();
            isCooling = true;
            cooldownTimer = cooldownDuration;
        }
    }

    private void Update()
    {
        if (isCooling)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                isCooling = false;
            }
        }
    }
}