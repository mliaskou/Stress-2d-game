using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public int life;
    public int power;
    private int powerMin = 0;
    private int lifeMin = 0;

    public Text powerText;
    [SerializeField] Text lifeText;
    [SerializeField] UIControllerScene2 uiControllerScene2;
    [SerializeField] StoreManager storeManager;
    [SerializeField] Text timeText;
    public float timeLeft = 30f;

    void Start()
    {
        powerText.text = storeManager.getPlayerPower().ToString();
        lifeText.text = storeManager.getPlayerLives().ToString();
    }

    private void Update()
    {


        timeLeft -= Time.deltaTime; // Set the timer
        timeLeft = Mathf.Clamp(timeLeft, 0, 30);
        timeText.text = (timeLeft).ToString("0");

        CheckLivesPower();

        if (life > 0 && timeLeft <= 0)
        {

            uiControllerScene2.ShowWinScreen();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Thought"))
        {
            life--;
            power--;
            powerText.text = power.ToString();
            lifeText.text = life.ToString();


            StoreManager.instance.setPlayerLives(life);
            StoreManager.instance.setPlayerPower(power);
        }

        if (collision.gameObject.CompareTag("Life"))
        {
            life++;
            lifeText.text = life.ToString();

            StoreManager.instance.setPlayerLives(life);

        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
            power++;
            powerText.text = power.ToString();
            StoreManager.instance.setPlayerPower(power);
        }

        if (life <= 0)
        {
            uiControllerScene2.ShowGameOverScreen();


            if (life <= 0 && timeLeft <= 0)
            {
                uiControllerScene2.ShowGameOverScreen();

            }



        }
   
    }

    public void CheckLivesPower()
    {
        if (life < lifeMin)
        {
            life = lifeMin;

        }

        if (power < powerMin)
        {
            power = powerMin;
        }

        lifeText.text = life.ToString();
        powerText.text = power.ToString();
        StoreManager.instance.setPlayerPower(power);
    }
}
