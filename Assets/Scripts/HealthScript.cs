using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int healthAmount = 100;
    public MenuManager menu;

    public void LoseHealth(int value)
    {
        healthAmount -= value;
        menu.ShowHealthBoss(healthAmount);
        if(healthAmount <= 0)
        {
            GameManager.instance.InvokeSuccess();
        }
    }

    private void Start()
    {
        menu = GameObject.Find("MENUMANAGER").GetComponent<MenuManager>();
    }

}
