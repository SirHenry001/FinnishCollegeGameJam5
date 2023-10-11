using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidScript : MonoBehaviour
{
    public bool lidOpening;
    public float speed;
    public Quaternion target;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.ChanceToMelt += OpenLid;
        GameManager.FrostModeActivate += CloseLid;
    }



    private void Update()
    {
        if(lidOpening)
        {
            
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
