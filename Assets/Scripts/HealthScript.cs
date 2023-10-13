using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int healthAmount = 1000;
    public MenuManager menu;
    public GameObject player;

    public void LoseHealth(int value)
    {
        healthAmount -= value;
        menu.ShowHealthBoss(healthAmount);
        if(healthAmount <= 0)
        {
            player.gameObject.tag = "Untagged";
            healthAmount = 0;
            GameManager.instance.InvokeSuccess();
        }
    }

    private void Start()
    {
        menu = GameObject.Find("MENUMANAGER").GetComponent<MenuManager>();
    }

}
