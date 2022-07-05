using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public GameObject Coin;
    public AudioSource Audio;
    public Collider CoinCollider;
    public MeshRenderer CoinMesh;

    private void OnTriggerEnter(Collider other)
    {
        PlayerCoins playerCoins = other.GetComponent<PlayerCoins>();
        if (playerCoins != null)
        {
            playerCoins.AddCoin();
            Audio.Play();
            CoinCollider.enabled = false;
            CoinMesh.enabled = false;
            StartCoroutine(DeactivateCoin());
        }
    }

    public IEnumerator DeactivateCoin()
    {
        yield return new WaitForSeconds(1);
        Coin.SetActive(false);
    }
}
