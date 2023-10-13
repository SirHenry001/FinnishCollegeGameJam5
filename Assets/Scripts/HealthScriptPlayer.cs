using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScriptPlayer : MonoBehaviour
{
    public int healthAmount = 100;
    public MenuManager menu;
    public GameObject player;

    public bool gameEnd;
    public float endTimer = 0.2f;

    //public bool debugImmortal;

    public void LoseHealth(int value)
    {
        healthAmount -= value;
        menu.ShowHealthPlayer(healthAmount);
        if (healthAmount <= 0)
        {
            healthAmount = 0;
            gameEnd = true;
        }
    }



    private void Start()
    {
        menu = GameObject.Find("MENUMANAGER").GetComponent<MenuManager>();
    }

    private void Update()
    {
        if(gameEnd)
        {
            if(endTimer < 0.6f)
            endTimer -= Time.deltaTime;
            if(endTimer <= 0)
            {
                endTimer = 0.7f;
                GameManager.instance.InvokeLevelFail();
            }
        }
        

        /*
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(!debugImmortal)
            {
                Debug.Log("kuolemattomuus");
                debugImmortal = true;
            }
            else if(debugImmortal)
            {
                Debug.Log("kuolevainen");
                debugImmortal = false;
            }

        }
        if (debugImmortal)
        {
            //Debug.Log("kuolematon");
            healthAmount = 100;
        }
        */
    }


}
