using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorScript Door;
    public AudioSource Audio;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHP playerHP = other.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            Audio.Play();
            Door.ActivateDoor();
        }
    }
}
