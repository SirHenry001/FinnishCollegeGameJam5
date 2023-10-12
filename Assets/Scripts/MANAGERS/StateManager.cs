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
    public bool meltStart;
    public bool meltProgress;
    public bool chanceProgress;

    public bool levelActive;

    public static StateManager instance;

    public enum LevelState
    {
        FrostMode,
        MeltMode,
        ChanceForMelt,
    }

    private void Awake()
    {
        Time.timeScale = 1;

        if (instance != null) { Debug.Log("trying to create another!"); }
        else { instance = this;  }


    }

    private void Start()
    {
        state = LevelState.FrostMode;
        //GameManager.instance.InvokeFrost();

        timerFrostMode = frostDefault;
        timerChanceForMelt = chanceDefault;
        timerMeltMode = meltDefault;

        StartCoroutine(StateLoop());
    }

    IEnumerator StateLoop()
    {
        while(!meltProgress)
        {
            Debug.Log("Frost");
            state = LevelState.FrostMode;
            GameManager.instance.InvokeFrost();
            yield return new WaitForSecondsRealtime(frostDefault);
            Debug.Log("CHANGE");
            state = LevelState.ChanceForMelt;
            GameManager.instance.InvokeChanceToMelt();
            yield return new WaitForSecondsRealtime(chanceDefault);
        }
    }
    public void StopCoroutines()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        if(state == LevelState.MeltMode && !meltProgress)
        {

            meltProgress = true;
            StopCoroutines();
            GameManager.instance.InvokeMelt();
            meltStart = true;
        }
        if(meltStart)
        {
            timerMeltMode -= Time.deltaTime;
            if(timerMeltMode <= 0)
            {
                meltStart = false;
                timerMeltMode = meltDefault;
                meltProgress = false;
                StartCoroutine(StateLoop());
            }
        }

        /*
        if( state != LevelState.MeltMode)
        {

            if (timerFrostMode < frostDefault && timerFrostMode > frostDefault - 0.007f)
            {
                GameManager.instance.InvokeFrost();
                state = LevelState.FrostMode;
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
        */
    }

    private void OnDestroy()
    {
        GameManager.instance.ResetInvokes();
    }
}
