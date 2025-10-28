using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController s_Instance;
    [SerializeField] private InformationStatusScreen _informationStatusScreen;

    [Header("Lives-Weapons-Distance Texts")]
    [SerializeField] Text _numberOfWeaponsText;
    [SerializeField] Text _numberOfLivesText;
    [SerializeField] Text _distanceTravelledText;

    private int numberOflives;
    private int numberOfWeapons;
    private float distanceTravelled;

    [Header("Reload Panel")]
    [SerializeField] GameObject reloadScenePanel;
    [SerializeField] GameObject panelBeforeTheNextScene;

    public void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeUI();
    }

    private void InitializeUI()
    {
        _numberOfLivesText.text = GetNumberOfLives();
        _numberOfWeaponsText.text = GetNumberOfWeapons();
        _distanceTravelledText.text = GetDistanceTravelledRounded();
    }
    public void ShowGameOverScreen()
    {
        _informationStatusScreen.SetInformationStatusGameOverScreen
        ("Game Over", GetNumberOfLives().ToString(), GetNumberOfWeapons().ToString(), GetDistanceTravelledRounded()
        , "Reload Game", ReloadScene);
    }

    public void ShowWinScreen()
    {
        _informationStatusScreen.SetInformationStatusWinScreen
        ("You Won!", GetNumberOfLives().ToString(), GetNumberOfWeapons().ToString(), GetDistanceTravelledRounded(),
        "Load next scene", LoadSecondScene);
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

    public void PanelBeforeTheNextScene()
    {
        panelBeforeTheNextScene.SetActive(true);
    }

    public void SetNumberOfWeapons(int power)
    {
        numberOfWeapons = power;
        _numberOfWeaponsText.text = $"Number of weapons: {numberOfWeapons.ToString()}";
    }

    public string GetNumberOfWeapons()
    {
        Debug.LogError("Get number of weapons");
        return $"Number of Weapons: {numberOfWeapons}";
    }

    public void UpdateNumberOfLivesUI(int lives)
    {
        numberOflives = lives;
        _numberOfLivesText.text = $"Number of lives: {numberOflives.ToString()}";
    }

    public string GetNumberOfLives()
    {
        return $"Number of lives: {numberOflives}";
    }

    public void SetDistanceTravelled(float distance)
    {
        distanceTravelled = distance;
        _distanceTravelledText.text = $"Distance travelled: {(int)Mathf.Ceil(distanceTravelled)}";
    }

    public string GetDistanceTravelledRounded()
    {
        return $"Distance Travelled: {(int)Mathf.Ceil(distanceTravelled)}";
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene("SecondScene");
    }
}

