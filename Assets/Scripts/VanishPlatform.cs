using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishPlatform : MonoBehaviour
{
    public GameObject VanishingPlatform;
    public float TimeToVanish;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHP playerHP = collision.gameObject.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            StartCoroutine(WaitToVanish());
        }
    }

    public IEnumerator WaitToVanish()
    {
        yield return new WaitForSeconds(TimeToVanish);
        VanishingPlatform.SetActive(false);

    }
}
