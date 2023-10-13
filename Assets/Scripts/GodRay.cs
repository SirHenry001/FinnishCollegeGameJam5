using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodRay : MonoBehaviour
{

    public GameObject ray1;
    public GameObject ray2;

    private void Awake()
    {
        GameManager.ChanceToMelt += ActivateRayOne;
        GameManager.MeltModeActivate += ActivateRayTwo;
        GameManager.FrostModeActivate += DisableRays;
    }

    private void DisableRays()
    {
        ray1.SetActive(false);
        ray2.SetActive(false);
    }

    private void ActivateRayOne()
    {
        ray1.SetActive(true);
        ray2.SetActive(false);
    }

    private void ActivateRayTwo()
    {
        ray1.SetActive(true);
        ray2.SetActive(true);
    }

}
