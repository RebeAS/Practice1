using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoins : MonoBehaviour
{
    public int TotalCoins = 0;
    public Text CoinCounter;

    public void AddCoin()
    {
        TotalCoins++;
    }

    private void Update()
    {
        CoinCounter.text = TotalCoins.ToString("000");
    }
}
