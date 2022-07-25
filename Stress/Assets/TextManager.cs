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

    [SerializeField] Text powerText;
    [SerializeField] Text lifeText;


    void Start()
    {
        powerText.text = StoreManager.instance.getPlayerPower().ToString();
        lifeText.text = StoreManager.instance.getPlayerLives().ToString();
    }

    private void Update()
    {

        if (life <= lifeMin)
        {
            life = lifeMin;
            lifeText.text = life.ToString();
        }

        if (power <= powerMin)
        {
            power = powerMin;
            powerText.text = power.ToString();
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


       
    }
}
