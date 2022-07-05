using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    public int DamageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHP playerHP = other.gameObject.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            playerHP.TakeDamage(DamageAmount);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHP playerHP = collision.gameObject.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            playerHP.TakeDamage(DamageAmount);
        }
    }
}
