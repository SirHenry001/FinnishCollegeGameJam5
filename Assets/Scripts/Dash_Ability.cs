using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Ability : MonoBehaviour
{
    //PLAYER CORE COMPONENT
    public PlayerCore core;

    public float dashPower;

    public void Dash()
    {
        core.rb.AddForce(transform.forward * dashPower, ForceMode.Impulse);
    }
}
