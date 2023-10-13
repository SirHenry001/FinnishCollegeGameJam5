using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("UI BOSS")]
    public Image healthBarBoss;
    public TextMeshProUGUI textBoss;

    [Header("UI PLAYER")]
    public Image healthBarPlayer;
    public Image dashBarPlayer;
    public Image meltLogo;
    //public TextMeshProUGUI textPlayer;


    [Header("UI GAME")]
    public GameObject allMenus;
    public GameObject reticle;
    public TextMeshProUGUI currentStateText; // käyttääkö tätä vai spesifimpää?
    public TextMeshProUGUI frostStateText;
    public TextMeshProUGUI meltStateText;
    public TextMeshProUGUI chanceStateText;

    [Header("UI MENUS")]
    public GameObject mainDisplay;
    public GameObject winDisplay;
    public GameObject loseDisplay;
    public GameObject settingsDisplay;

    [Header("BUTTONS")]
    public GameObject settingsButton;
    public GameObject startButton;
    public GameObject backButton;


    private void Awake()
    {
        Cursor.visible = true;
        GameManager.ChanceToMelt += ChanceState;
        GameManager.FrostModeActivate += FrostState;
        GameManager.MeltModeActivate += MeltState;

        GameManager.Success += GameWin;
        GameManager.Fail += GameLose;
    }

    private void Start()
    {
        AudioManager.instance.PlayMusicFX(1);
        StateManager.instance.levelActive = true;
    }

    public void ChanceState()
    {
        meltLogo.gameObject.SetActive(false);
        chanceStateText.gameObject.SetActive(true);
        frostStateText.gameObject.SetActive(false);
        meltStateText.gameObject.SetActive(false);
    }
    public void FrostState()
    {
        meltLogo.gameObject.SetActive(false);
        chanceStateText.gameObject.SetActive(false);
        frostStateText.gameObject.SetActive(true);
        meltStateText.gameObject.SetActive(false);
    }
    public void MeltState()
    {
        meltLogo.gameObject.SetActive(true);
        chanceStateText.gameObject.SetActive(false);
        frostStateText.gameObject.SetActive(false);
        meltStateText.gameObject.SetActive(true);
    }

    public void ShowHealthBoss(int value)
    {
        healthBarBoss.fillAmount = value * 0.001f;
    }
    public void ShowHealthPlayer(int value)
    {
        healthBarPlayer.fillAmount = value * 0.01f;
    }
    public void DashBar(float value)
    {
        value += dashBarPlayer.fillAmount;
        dashBarPlayer.fillAmount += value * 0.01f; ;
    }

    public void GameWin()
    {
        AudioManager.instance.PlayMusicFX(2);
        winDisplay.SetActive(true);
        allMenus.SetActive(false);
        reticle.SetActive(false);
        StateManager.instance.levelActive = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void GameLose()
    {
        Time.timeScale = 0;
        loseDisplay.SetActive(true);
        StateManager.instance.levelActive = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void MainMenu()
    {
        mainDisplay.SetActive(true);
    }

    //Button Calls
    public void StartButton()
    {
        StateManager.instance.levelActive = true;
        Time.timeScale = 1;
    }
    public void MainMenuButton(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void SettingsButton()
    {

    }
    private void OnDestroy()
    {
        GameManager.instance.ResetInvokes();
    }

}
