using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIControllerScene2 : MonoBehaviour
{
    public GameObject GameOverScreen;
    [SerializeField] TextManager textManager;
    [SerializeField] Text weapons;
    [SerializeField] GameObject reloadScenePanel;
    [SerializeField] GameObject winScenePanel;

    [SerializeField] Text weaponsTextWin;
    [SerializeField] Text livesWin;
    //[SerializeField] GameObject panelBeforeTheNextScene;
   
    public void Update()
    {
        weapons.text = textManager.powerText.text;

    }
    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
        
    }

    public void ReloadScenePanel()
    {
        reloadScenePanel.SetActive(true);
        
    }
  

    public void GameQuit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ShowWinScreen()
    {
        winScenePanel.SetActive(true);
        livesWin.text = textManager.life.ToString();
        
        weaponsTextWin.text = textManager.power.ToString();

    }

 
    public void LoadSecondScene()
    {
        Debug.Log("Playing");
        SceneManager.LoadScene(2);
        
    }

    public void LoadThirdScene()
    {
        SceneManager.LoadScene(3);
    }
}
