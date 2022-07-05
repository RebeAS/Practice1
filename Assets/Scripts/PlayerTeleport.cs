using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }

    public void Teleport(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void TeleportToInitialPosition()
    {
        Teleport(initialPos);
    }
}
