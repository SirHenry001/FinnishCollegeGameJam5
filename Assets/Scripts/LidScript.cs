using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidScript : MonoBehaviour
{
    public bool lidOpening;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        lidOpening = false;

        GameManager.ChanceToMelt += OpenLid;
        GameManager.FrostModeActivate += CloseLid;
    }



    private void Update()
    {
        if(lidOpening)
        {
            anim.SetBool("Open",true);
        }
        else
        {
            anim.SetBool("Open", false);
        }
    }

    private void OpenLid()
    {
        lidOpening = true;
    }
    private void CloseLid()
    {
        lidOpening = false;
    }
}
