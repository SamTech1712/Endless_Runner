using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDustController : MonoBehaviour
{
    public NewPlayerMovement player_Movement;
    public ParticleSystem particle;

    public float particleSpeed;
    public float relativeParticleCount;
  
    void Update()
    {
        if (player_Movement.isGrounded)
        {
            var emmision = particle.emission;
            emmision.enabled = true; ;

            var velocity = particle.velocityOverLifetime;
            velocity.x = player_Movement.velocity * particleSpeed;

            var main = particle.main;
            main.maxParticles = (int)Mathf.Abs(player_Movement.velocity * relativeParticleCount);
        }
        else
        {
            var emmision = particle.emission;
            emmision.enabled = false;
        }
    }
}
