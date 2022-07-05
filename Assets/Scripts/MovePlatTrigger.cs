using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatTrigger : MonoBehaviour
{
    public Transform Platform;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHP playerHP = other.gameObject.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            other.transform.SetParent(Platform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerHP playerHP = other.gameObject.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            other.transform.SetParent(null);
        }
    }
}
