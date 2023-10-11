using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Ability : MonoBehaviour
{
    //PLAYER CORE COMPONENT
    public PlayerCore core;

    public float dashPower;


    public void DashDir(Vector2 value)
    {
        if(!core.isDashing)
        {
            if (value.x > 0)
            {
                core.rb.AddForce(transform.right * dashPower, ForceMode.Impulse);
                core.anim.SetTrigger("DashRight");
                StartCoroutine(DashCoolDown());
            }
            if (value.x < 0)
            {
                core.rb.AddForce(-transform.right * dashPower, ForceMode.Impulse);
                core.anim.SetTrigger("DashLeft");
                StartCoroutine(DashCoolDown());
            }
            if (value.y > 0)
            {
                core.rb.AddForce(transform.forward * dashPower, ForceMode.Impulse);
                core.anim.SetTrigger("DashFront");
                StartCoroutine(DashCoolDown());
            }
            if (value.y < 0)
            {
                core.rb.AddForce(-transform.forward * dashPower, ForceMode.Impulse);
                core.anim.SetTrigger("DashBack");
                StartCoroutine(DashCoolDown());
            }
            if (value.x == 0 || value.y == 0)
            {
                core.rb.AddForce(transform.forward * dashPower, ForceMode.Impulse);
                core.anim.SetTrigger("DashFront");
                StartCoroutine(DashCoolDown());
            }
        }


    }

    IEnumerator DashCoolDown()
    {

        core.isDashing = true;
        yield return new WaitForSecondsRealtime(0.5f);
        core.rb.velocity = Vector3.zero;
        yield return new WaitForSecondsRealtime(1.5f);
        core.isDashing = false;
    }
}
