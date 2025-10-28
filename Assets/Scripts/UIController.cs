using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController s_Instance;
    [SerializeField] private GameObject GameOverScreen;

    [Header("Lives-Weapons-Distance Texts")]
    [SerializeField] Text weaponsText;
    [SerializeField] Text livesText;
    [SerializeField] Text distanceTravelledText;

    private int numberOflives;
    private int numberOfWeapons;
    private float distanceTravelled;

    [Header("Reload Panel")]
    [SerializeField] GameObject reloadScenePanel;
    [Header("Win Panel")]
    [SerializeField] GameObject winScenePanel;
    [SerializeField] Text distanceTravelledWin;
    [SerializeField] Text weaponsTextWin;
    [SerializeField] Text livesWin;

    [SerializeField] GameObject panelBeforeTheNextScene;


    void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
        distanceTravelledText.text = GetDistanceTravelledRounded();
        weaponsText.text = GetNumberOfWeapons().ToString();
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ShowWinScreen()
    {
        winScenePanel.SetActive(true);
        livesWin.text = GetNumberOfLives().ToString();
        distanceTravelledWin.text = GetDistanceTravelledRounded();
        weaponsTextWin.text = GetNumberOfWeapons().ToString();
    }

    public void PanelBeforeTheNextScene()
    {
        panelBeforeTheNextScene.SetActive(true);
    }

    public void SetNumberOfWeapons(int power)
    {

        numberOfWeapons = power;
        weaponsText.text = $"Number of weapons: {numberOfWeapons.ToString()}";
    }

    public int GetNumberOfWeapons()
    {
        return numberOfWeapons;
    }

    public void UpdateNumberOfLivesUI(int lives)
    {
        if (lives <= 0)
        {
            lives = 0;
        }
        numberOflives = lives;
        livesText.text = $"Number of lives: {numberOflives.ToString()}";
    }

    public int GetNumberOfLives()
    {
        return numberOflives;
    }

    public void SetDistanceTravelled(float distance)
    {
        distanceTravelled = distance;
        distanceTravelledText.text = $"Distance travelled: {(int)Mathf.Ceil(distanceTravelled)}";
    }

    public string GetDistanceTravelledRounded()
    {
        return $"Distance Travelled: {(int)Mathf.Ceil(distanceTravelled)} meters";
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene("SecondScene");
    }
}

