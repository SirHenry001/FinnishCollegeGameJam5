using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("UI BOSS")]
    public static Image healthBarBoss;
    public TextMeshProUGUI textBoss;

    [Header("UI PLAYER")]
    public static Image healthBarPlayer;
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

    public static void ShowHealthBoss(int value)
    {
        healthBarBoss.fillAmount = value * 0.0001f;


    }
    public static void ShowHealthPlayer(int value)
    {
        healthBarPlayer.fillAmount = value * 0.0001f;
    }

}
