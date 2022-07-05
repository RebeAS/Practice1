using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform Platform;
    public Transform InitialPos;
    public Transform FinalPos;

    public float LerpTime;
    private float elapsedTime;

    public float WaitTime;
    private float timeWaited;

    private void FixedUpdate()
    {
        if (elapsedTime < LerpTime)
        {
            elapsedTime += Time.deltaTime;
            Platform.position = Vector3.Lerp(InitialPos.position, FinalPos.position, elapsedTime / LerpTime);
        }
        else
        {
            timeWaited += Time.deltaTime;
            if (timeWaited > WaitTime)
            {
                SwapPositions();
                elapsedTime = 0;
                timeWaited = 0;
            }
        }
    }

    public void SwapPositions()
    {
        Transform temp = InitialPos;
        InitialPos = FinalPos;
        FinalPos = temp;
    }
}
