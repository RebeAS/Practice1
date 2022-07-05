using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool RemainsOpen;
    private bool isWorking;
    public float TimeToOpen;
    public float TimeToClose;

    public AudioSource Audio;

    public Transform Door, InitialPos, FinalPos;

    public IEnumerator OpenDoor()
    {
        float elapsedTime = 0;

        Audio.Play();
        while (elapsedTime < TimeToOpen)
        {
            elapsedTime += Time.deltaTime;
            Door.position = Vector3.Lerp(InitialPos.position, FinalPos.position, elapsedTime / TimeToOpen);
            yield return null;
        }

        if (!RemainsOpen)
        {
            yield return new WaitForSeconds(TimeToClose);
            DeactivateDoor();
        }
    }

    public IEnumerator CloseDoor()
    {
        float elapsedTime = 0;

        Audio.Play();
        while (elapsedTime < TimeToClose)
        {
            elapsedTime += Time.deltaTime;
            Door.position = Vector3.Lerp(FinalPos.position, InitialPos.position, elapsedTime / TimeToClose);
            yield return null;
        }

        isWorking = false;
    }

    public void ActivateDoor()
    {
        if (!isWorking)
        {
            StartCoroutine(OpenDoor());
            isWorking = true;
        }
    }

    public void DeactivateDoor()
    {
        StartCoroutine(CloseDoor());
    }
}
