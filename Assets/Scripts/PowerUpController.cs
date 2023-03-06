using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] private Image imagePowerUp;
    private GameObject player;
    private bool isPowerUp = false;
    private bool isDirectionUp = true;
    private float currentPower = 0f;
    private float maxPower = 100f;

    private float powerUpSpeed = 100f;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (isPowerUp)
        {
            PowerActive();
        }
    }

    private void PowerActive()
    {
        if (isDirectionUp){
            currentPower += powerUpSpeed * Time.deltaTime;
            if (currentPower >= maxPower)
            {
                isDirectionUp = false;
                currentPower = maxPower;
            }
        }
        else
        {
            currentPower -= powerUpSpeed * Time.deltaTime;
            if (currentPower <= 0)
            {
                isDirectionUp = true;
                currentPower = 0;
            }
        }
        imagePowerUp.fillAmount = currentPower / maxPower;
    }

    public void StartPowerUp()
    {
        isPowerUp = true;
        currentPower = 0;
        isDirectionUp = true;
    }

    public void StopPowerUp()
    {
        //JUMP
        player.GetComponent<PlayerInputController>().Jump(currentPower/maxPower);
        isPowerUp = false;
        currentPower = 0;
        isDirectionUp = true;
    }

}
