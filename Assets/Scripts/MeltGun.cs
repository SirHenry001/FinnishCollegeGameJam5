using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltGun : MonoBehaviour
{
    public GameObject spawnPos;
    public GameObject meltGunAmmo;

    private void Awake()
    {
        gameObject.SetActive(false);
        GameManager.MeltModeActivate += ActivateMeltGun;
    }

    private void ActivateMeltGun()
    {
        gameObject.SetActive(true);
        Instantiate(meltGunAmmo, spawnPos.transform.position, spawnPos.transform.rotation);
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        yield return new WaitForSecondsRealtime(StateManager.instance.meltDefault);
        gameObject.SetActive(false);
    }
}
