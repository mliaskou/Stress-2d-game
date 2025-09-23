using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject GameOverScreen;
    [SerializeField] Text distanceTravelled;
    [SerializeField] Player player;
    float roundedDistance;
    [SerializeField] Text weapons;
    [SerializeField] GameObject reloadScenePanel;
    [SerializeField] GameObject winScenePanel;

    [SerializeField] Text distanceTravelledWin;
    [SerializeField] Text weaponsTextWin;
    [SerializeField] Text livesWin;
    [SerializeField] Platform platform;
    [SerializeField] GameObject panelBeforeTheNextScene;
    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
        distanceTravelled.text = player.distanceTravelled.ToString();
        roundedDistance = Mathf.Ceil(player.distanceTravelled);
        distanceTravelled.text = "" + roundedDistance;
        weapons.text = player.power.ToString();
    }

    public void ReloadScenePanel()
    {
        reloadScenePanel.SetActive(true);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameQuit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ShowWinScreen()
    {
        winScenePanel.SetActive(true);
        livesWin.text = player.life.ToString();
        distanceTravelledWin.text = player.distanceTravelled.ToString();
        roundedDistance = Mathf.Ceil(player.distanceTravelled);
        distanceTravelledWin.text = "" + roundedDistance;
        weaponsTextWin.text = player.power.ToString();
        
    }

    public void PanelBeforeTheNextScene()
    {
        panelBeforeTheNextScene.SetActive(true);
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene("SecondScene");
    }
}

