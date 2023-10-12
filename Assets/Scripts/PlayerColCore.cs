using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColCore : MonoBehaviour
{
    public HealthScriptPlayer hp;
    public MenuManager menu;
    public PlayerCore core;
    public GameObject FX;




    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyLong" || collision.gameObject.tag == "EnemyLong")
        {
            core.anim.SetTrigger("Hit");
            Instantiate(FX, gameObject.transform.position, transform.rotation);
            Destroy(FX, 2f);
        }

    }

}
