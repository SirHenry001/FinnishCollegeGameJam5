using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScriptPlayer : MonoBehaviour
{
    public int healthAmount = 100;
    public MenuManager menu;

    public void LoseHealth(int value)
    {
        healthAmount -= value;
        menu.ShowHealthPlayer(healthAmount);
        if (healthAmount <= 0)
        {
            GameManager.instance.InvokeLevelFail();
        }
    }

    private void Start()
    {
        menu = GameObject.Find("MENUMANAGER").GetComponent<MenuManager>();
    }
}
