using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    public float RotSpeed;

    private void Update()
    {
        transform.Rotate(0, RotSpeed * Time.deltaTime, 0);
    }
}
