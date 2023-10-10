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
        Debug.Log("Frost");

        timerFrostMode = frostDefault;
        timerChanceForMelt = chanceDefault;
        timerMeltMode = meltDefault;
    }

    public void StopCoroutines()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        if( state != LevelState.MeltMode)
        {

            if (timerFrostMode < frostDefault && timerFrostMode > frostDefault - 0.007f)
            {
                GameManager.instance.InvokeFrost();
                state = LevelState.FrostMode;
                Debug.Log("Frost");
            }


            frostProgress = true;
            chanceProgress = false;
            timerFrostMode -= Time.deltaTime;
            if (timerFrostMode <= 0)
            {

                if (timerChanceForMelt < chanceDefault && timerChanceForMelt > chanceDefault - 0.007f)
                {
                    state = LevelState.ChanceForMelt;
                    GameManager.instance.InvokeChanceToMelt();
                    Debug.Log("Chance");
                }


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


            if (timerMeltMode < meltDefault && timerMeltMode > meltDefault - 0.007f)
            {
                GameManager.instance.InvokeMelt();
                state = LevelState.MeltMode;
                Debug.Log(LevelState.MeltMode);
            }
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
    }
}
