using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDustController : MonoBehaviour
{
    Rigidbody2D playerGravity;
    [SerializeField]
    private ParticleSystem particle;

    [SerializeField]
    private float multiplier;

    private ParticleSystem.EmissionModule emmision;

    private void Start()
    {
        playerGravity = PlayerReference.player.GetComponent<Rigidbody2D>();
        emmision = particle.emission;
    }

    void Update()
    {
        emmision.rateOverTime = (1 - playerGravity.gravityScale) * multiplier;
    }
}
