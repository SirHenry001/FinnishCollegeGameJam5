using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameAction();
    public static event GameAction Success;
    public static event GameAction Fail;

    public delegate void LevelAction();
    public static event LevelAction ChanceToMelt;
    public static event LevelAction FrostModeActivate;
    public static event LevelAction MeltModeActivate;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        { Destroy(gameObject); }
        else
        { instance = this; DontDestroyOnLoad(instance); }
    }

    //INVOKE GAME EVENTS FUNCTIONS
    public void InvokeSuccess()
    { Success?.Invoke(); }
    public void InvokeLevelFail()
    { Fail?.Invoke(); }

    //INVOKE LEVEL EVENTS FUNCTIONS
    public void InvokeFrost()
    { FrostModeActivate?.Invoke();}
    public void InvokeMelt()
    { MeltModeActivate?.Invoke();}
    public void InvokeChanceToMelt()
    { ChanceToMelt?.Invoke();}

    public void ResetInvokes() // k‰ytet‰‰n t‰ss‰ functiossa kun ladataan scene uudestaan esim menness‰ retryyn tai muuten navigointi
    {
        Success = null;
        Fail = null;
        ChanceToMelt = null;
        FrostModeActivate = null;
        MeltModeActivate = null;
    }

}
