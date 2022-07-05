using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public float LifeTime;

    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    public IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
