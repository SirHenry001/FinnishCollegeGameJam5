using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Ability : MonoBehaviour
{
    //PLAYER CORE COMPONENT
    public PlayerCore core;
    public MenuManager menu;

    public float dashPower;
    public float dashValue;

    public bool coolDownOn;

    private void Start()
    {
        dashValue = 100;
        menu = GameObject.Find("MENUMANAGER").GetComponent<MenuManager>();
    }

    private void Update()
    {
        if (coolDownOn)
        {
            menu.DashBar(0.001f);
            if (menu.dashBarPlayer.fillAmount == 1)
            {
                coolDownOn = false;
            }
        }
    }

    public void DashDir(Vector2 value)
    {
        if(!core.isDashing)
        {
            if (value.x > 0)
            {
                core.rb.AddForce(transform.right * dashPower, ForceMode.Impulse);
                core.anim.SetTrigger("DashFront");
                StartCoroutine(DashCoolDown());
                menu.dashBarPlayer.fillAmount = 0;

            }
            if (value.x < 0)
            {
                core.rb.AddForce(-transform.right * dashPower, ForceMode.Impulse);
                core.anim.SetTrigger("DashFront");
                StartCoroutine(DashCoolDown());
                menu.dashBarPlayer.fillAmount = 0;
            }
            if (value.y > 0)
            {
                core.rb.AddForce(transform.forward * dashPower, ForceMode.Impulse);
                core.anim.SetTrigger("DashFront");
                StartCoroutine(DashCoolDown());
                menu.dashBarPlayer.fillAmount = 0;
            }
            if (value.y < 0)
            {
                core.rb.AddForce(-transform.forward * dashPower, ForceMode.Impulse);
                core.anim.SetTrigger("DashFront");
                StartCoroutine(DashCoolDown());
                menu.dashBarPlayer.fillAmount = 0;
            }
            if (value.x == 0 || value.y == 0)
            {
                core.rb.AddForce(transform.forward * dashPower, ForceMode.Impulse);
                core.anim.SetTrigger("DashFront");
                StartCoroutine(DashCoolDown());
                menu.dashBarPlayer.fillAmount = 0;
            }
        }



    }

    IEnumerator DashCoolDown()
    {
        coolDownOn = true;
        core.isDashing = true;
        yield return new WaitForSecondsRealtime(0.5f);
        core.rb.velocity = Vector3.zero;
        yield return new WaitUntil(() => !coolDownOn);
        core.isDashing = false;
    }
}
