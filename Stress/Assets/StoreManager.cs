using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance;


    private void Awake()
    {
        if (instance != null && instance!=this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    public void setPlayerLives(int lives)
    {
        PlayerPrefs.SetInt("PlayerLives", lives);
    }

    public int getPlayerLives()
    {
        return PlayerPrefs.GetInt("PlayerLives", 0);
    }


    public void setPlayerPower(int powerUp)
    {
        PlayerPrefs.SetInt("PlayerPower", powerUp);
    }

    public int getPlayerPower()
    {
        return PlayerPrefs.GetInt("PlayerPower", 0);
    }
}
