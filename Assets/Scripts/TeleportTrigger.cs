using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform TeleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        PlayerTeleport playerTeleport = other.GetComponent<PlayerTeleport>();
        if (playerTeleport != null)
        {
            playerTeleport.Teleport(TeleportTarget.position);
        }
    }
}
