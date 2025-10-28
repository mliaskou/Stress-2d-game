using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InformationStatusScreen : MonoBehaviour
{
    [SerializeField] Image _backgroundImage;
    [SerializeField] Text _titleText;
    [SerializeField] Text _numberofLivesText;
    [SerializeField] Text _numberOfWeaponsText;
    [SerializeField] Text _distanceTravelledText;
    [SerializeField] Button _informationStatusScreenButton;

    public void SetInformationStatusWinScreen(string title, string lives, string numberOfWeapons, string distanceTravelled,
    string buttonText, UnityAction buttonListener)
    {
        _titleText.text = title;
        _numberofLivesText.text = lives;
        _numberOfWeaponsText.text = numberOfWeapons;
        _distanceTravelledText.text = distanceTravelled;
        _backgroundImage.sprite = Resources.Load<Sprite>("sky");
        _informationStatusScreenButton.onClick.RemoveAllListeners();
        _informationStatusScreenButton.GetComponentInChildren<Text>().text = buttonText;
        _informationStatusScreenButton.onClick.AddListener(() =>
        {
            buttonListener?.Invoke();
            Reset();
        });
        gameObject.SetActive(true);
    }

    public void SetInformationStatusGameOverScreen(string title, string lives, string numberOfWeapons, string distanceTravelled,
    string buttonText, UnityAction buttonListener)
    {
        _titleText.text = title;
        _numberofLivesText.text = lives;
        _numberOfWeaponsText.text = numberOfWeapons;
        _distanceTravelledText.text = distanceTravelled;
        _backgroundImage.sprite = Resources.Load<Sprite>("sky");
        _informationStatusScreenButton.onClick.RemoveAllListeners();
        _informationStatusScreenButton.GetComponentInChildren<Text>().text = buttonText;
        _informationStatusScreenButton.onClick.AddListener(() =>
        {
            buttonListener?.Invoke();
            Reset();
        });
        gameObject.SetActive(true);
    }

    public void Reset()
    {
        _titleText.text = "";
        _numberofLivesText.text = "";
        _numberOfWeaponsText.text = "";
        _distanceTravelledText.text = "";
        _informationStatusScreenButton.onClick.RemoveAllListeners();
        _informationStatusScreenButton.GetComponentInChildren<Text>().text = "";
    }
}
