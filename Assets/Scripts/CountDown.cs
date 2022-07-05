using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float CountdownDuration = 60;
    private float remainingTime;

    public Text CountdownText;
    public Image CountdownImage;

    private PlayerHP myHP;

    private void Start()
    {
        RestartCountdown();
        CountdownImage.fillAmount = 1;
        myHP = GetComponent<PlayerHP>();
    }

    public void RestartCountdown()
    {
        remainingTime = CountdownDuration;
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            CountdownText.text = remainingTime.ToString("0.00");
            CountdownImage.fillAmount = Mathf.InverseLerp(0, CountdownDuration, remainingTime);
        }
        else
        {
            myHP.TakeDamage(100);
            RestartCountdown();
        }
    }
}
