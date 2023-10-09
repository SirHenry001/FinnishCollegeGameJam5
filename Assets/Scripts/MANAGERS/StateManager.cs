using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [Header("Level State")]
    public LevelState state;

    [Header("Timers for levelChance")]
    public float timerFrostMode;
    public float timerChanceForMelt;
    public float timerMeltMode;

    [Header("Variables for levelChance")]
    public float frostDefault;
    public float chanceDefault;
    public float meltDefault;

    public bool frostProgress;
    public bool meltProgress;
    public bool chanceProgress;

    public static StateManager instance;

    public enum LevelState
    {
        FrostMode,
        MeltMode,
        ChanceForMelt,
    }

    private void Awake()
    {
        if (instance != null)
        { Destroy(gameObject); }
        else
        { instance = this; DontDestroyOnLoad(instance); }
    }

    private void Start()
    {
        state = LevelState.FrostMode;
        GameManager.instance.InvokeFrost();

        timerFrostMode = frostDefault;
        timerChanceForMelt = chanceDefault;
        timerMeltMode = meltDefault;
    }

    public void ChangeState(LevelState state)
    {
        switch (state)
        {
            case LevelState.FrostMode:
                
                GameManager.instance.InvokeMelt();
                Debug.Log("FROST!");
                break;
            case LevelState.MeltMode:
                state = LevelState.MeltMode;
                GameManager.instance.InvokeFrost();
                Debug.Log("MELT"!);
                break;
            case LevelState.ChanceForMelt:
                state = LevelState.ChanceForMelt;
                GameManager.instance.InvokeChanceToMelt();
                Debug.Log("CHANCE FOR MELTIN MODE!");
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if( state != LevelState.MeltMode)
        {
            GameManager.instance.InvokeFrost();
            state = LevelState.FrostMode;
            timerFrostMode -= Time.deltaTime;
            frostProgress = true;
            chanceProgress = false;
            if (timerFrostMode <= 0)
            {
                state = LevelState.ChanceForMelt;
                GameManager.instance.InvokeChanceToMelt();
                frostProgress = false;
                chanceProgress = true;
                timerFrostMode = 0;
                timerChanceForMelt -= Time.deltaTime;
                if (timerChanceForMelt <= 0)
                {
                    timerChanceForMelt = 0;
                    timerFrostMode = frostDefault;
                    timerChanceForMelt = chanceDefault;
                }
            }
        }
        else if(state == LevelState.MeltMode)
        {
            GameManager.instance.InvokeMelt();
            state = LevelState.MeltMode;
            frostProgress = false;
            chanceProgress = false;
            timerMeltMode -= Time.deltaTime;
            meltProgress = true;

            if (timerMeltMode <= 0)
            {
                timerFrostMode = frostDefault;
                timerChanceForMelt = chanceDefault;
                state = LevelState.FrostMode;
                timerMeltMode = meltDefault;
                meltProgress = false;
            }
        }

        /*
        ChangeState(LevelState.FrostMode);
        ChangeState(LevelState.ChanceForMelt);
        ChangeState(LevelState.MeltMode);
        */
    }
}
