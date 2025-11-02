using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private InformationStatusScreen _informationStatusScreen;

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

    [Header("Timer")]
    [SerializeField] float timeLeft = 3f;
    [SerializeField] Text _timerText;

    public IEnumerator InitializeUIController(InformationStatusScreen informationStatusScreen)
    {
        _informationStatusScreen = informationStatusScreen;
        _informationStatusScreen.transform.SetParent(transform,false);
        _informationStatusScreen.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        InitializeUI();
        yield return null;
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
        , "Reload Game", AppManager.s_Instance.ReloadScene);
    }

    public void ShowWinScreen()
    {
        _informationStatusScreen.SetInformationStatusWinScreen
        ("You Won!", GetNumberOfLives().ToString(), GetNumberOfWeapons().ToString(), GetDistanceTravelledRounded(),
        "Load next scene", LoadSecondScene);
    }
    public void SetNumberOfWeapons(int power)
    {
        numberOfWeapons = power;
        _numberOfWeaponsText.text = $"Number of weapons: {numberOfWeapons.ToString()}";
    }

    public string GetNumberOfWeapons()
    {
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

    public void SetTimeScreen(Action onTimeEnd)
    {
        Debug.Log("SetTimeScreen");
        if (timeLeft > 0)
        {
            
            timeLeft -= Time.deltaTime;
            _timerText.text = (timeLeft).ToString("0");
            
            if (timeLeft <= 0)
            {
                _timerText.gameObject.SetActive(false);
                onTimeEnd?.Invoke();
            }
        }
    }

    public float GetTimer()
    {
        return timeLeft;
    }
}

