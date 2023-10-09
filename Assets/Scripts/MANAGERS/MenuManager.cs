using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("UI BOSS")]
    public Slider HealthBarBoss;
    public TextMeshProUGUI textBoss;

    [Header("UI PLAYER")]
    public Slider HealthBarPlayer;
    public TextMeshProUGUI textPlayer;

    [Header("UI GAME")]
    public TextMeshProUGUI currentStateText; // käyttääkö tätä vai spesifimpää? * 
    public TextMeshProUGUI frostStateText;
    public TextMeshProUGUI meltStateText;
    public TextMeshProUGUI chanceStateText;


    private void Awake()
    {
        GameManager.ChanceToMelt += ChanceState;
        GameManager.FrostModeActivate += FrostState;
        GameManager.MeltModeActivate += MeltState;
    }

    public void ChanceState()
    {
        chanceStateText.gameObject.SetActive(true);
        frostStateText.gameObject.SetActive(false);
        meltStateText.gameObject.SetActive(false);
    }
    public void FrostState()
    {
        chanceStateText.gameObject.SetActive(false);
        frostStateText.gameObject.SetActive(true);
        meltStateText.gameObject.SetActive(false);
    }
    public void MeltState()
    {
        chanceStateText.gameObject.SetActive(false);
        frostStateText.gameObject.SetActive(false);
        meltStateText.gameObject.SetActive(true);
    }

}
