using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{

    public float MaxHP;
    private float currentHP;
    public Image HealthBar;

    private PlayerTeleport myPlayerTeleport;
    private CountDown myCountDown;

    private void Start()
    {
        RestoreHP();
        HealthBar.fillAmount = 1;
        myPlayerTeleport = GetComponent<PlayerTeleport>();
        myCountDown = GetComponent<CountDown>();
    }

    public void RestoreHP()
    {
        currentHP = MaxHP;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHP -= damageAmount;
        if (currentHP <= 0)
        {
            Debug.Log("You died.");
            RestoreHP();
            myPlayerTeleport.TeleportToInitialPosition();
            myCountDown.RestartCountdown();
        }
        else
        {
            Debug.Log($"Ouch! My HP is {currentHP}.");
        }
    }

    public void Update()
    {
        HealthBar.fillAmount = Mathf.InverseLerp(0, MaxHP, currentHP);
    }
}
