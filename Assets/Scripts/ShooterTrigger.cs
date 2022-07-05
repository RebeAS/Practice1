using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTrigger : MonoBehaviour
{
    public ShooterTrap Shooter;
    public AudioSource Audio;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHP playerHP = other.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            Audio.Play();
            Shooter.OnActivation();
        }
    }
}
