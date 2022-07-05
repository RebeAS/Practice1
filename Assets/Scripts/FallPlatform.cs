using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    public GameObject FallingPlatform;
    public Rigidbody PlatformRB;
    private Vector3 initialPos;
    private Quaternion initialRot;
    public float TimeToFall;
    public float TimeToRestore;

    private void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    public void Teleport(Vector3 newPosition, Quaternion newRotation)
    {
        transform.position = newPosition;
        transform.rotation = newRotation;
    }

    public void TeleportToInitialPosition()
    {
        Teleport(initialPos, initialRot);
    }

    public IEnumerator RestoreTrap()
    {
        yield return new WaitForSeconds(TimeToRestore);
        PlatformRB.isKinematic = true;
        PlatformRB.useGravity = false;
        TeleportToInitialPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHP playerHP = collision.gameObject.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            StartCoroutine(WaitToFall());
        }
    }

    public IEnumerator WaitToFall()
    {
        yield return new WaitForSeconds(TimeToFall);
        PlatformRB.isKinematic = false;
        PlatformRB.useGravity = true;
        StartCoroutine(RestoreTrap());
    }
}
