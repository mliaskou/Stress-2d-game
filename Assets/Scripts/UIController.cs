using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    [Header("String Tags")]
    string _numberOfWeaponsTextTag = "Number of Weapons: ";
    string _numberOfLivesTextTag = "Number of Lives: ";
    string _distanceTravelledTextTag = "Distance Travelled: ";

    public IEnumerator InitializeUIController(InformationStatusScreen informationStatusScreen)
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        _informationStatusScreen = informationStatusScreen;
        _informationStatusScreen.transform.SetParent(transform, false);
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
        "Load next scene", AppManager.s_Instance.LoadSecondScene);
    }
    public void SetNumberOfWeapons(int power)
    {
        numberOfWeapons = power;
        _numberOfWeaponsText.text = $"{_numberOfWeaponsTextTag} {numberOfWeapons.ToString()}";
    }

    public string GetNumberOfWeapons()
    {
        return $"{_numberOfWeaponsTextTag}{numberOfWeapons}";
    }

    public void UpdateNumberOfLivesUI(int lives)
    {
        numberOflives = lives;
        _numberOfLivesText.text = $"{_numberOfLivesTextTag}{numberOflives.ToString()}";
    }

    public string GetNumberOfLives()
    {
        return $"{_numberOfLivesTextTag}  {numberOflives}";
    }

    public void SetDistanceTravelled(float distance)
    {
        distanceTravelled = distance;
        _distanceTravelledText.text = $"{_distanceTravelledTextTag}{(int)Mathf.Ceil(distanceTravelled)}";
    }

    public string GetDistanceTravelledRounded()
    {
        return $"{_distanceTravelledTextTag}{(int)Mathf.Ceil(distanceTravelled)}";
    }


    public void SetTimeScreen(Action onTimeEnd)
    {
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
}

