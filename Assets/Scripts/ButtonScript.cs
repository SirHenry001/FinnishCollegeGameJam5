using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public Animator anim;
    public GameObject FX;
    public GameObject fxPos;
    public Collider pressCol;

    public float minPosX;
    public float maxPosX;
    public float minPosZ;
    public float maxPosZ;

    public float variationTimer;
    public GameObject spawnPos;

    private void Awake()
    {
        GameManager.MeltModeActivate += ColliderControl;
        InvokeRepeating("LocationVariation", 0f, variationTimer);
    }

    private void ColliderControl()
    {
        StartCoroutine(Collider());
    }
    IEnumerator Collider()
    {
        pressCol.enabled = false;
        yield return new WaitForSecondsRealtime(StateManager.instance.meltDefault);
        pressCol.enabled = true;
    }

    public void LocationVariation()
    {
        gameObject.transform.position = new Vector3((Random.Range(minPosX, maxPosX)), transform.position.y, (Random.Range(minPosZ, maxPosZ)));
        GameObject clone = Instantiate(FX, fxPos.gameObject.transform.position, fxPos.gameObject.transform.rotation);
        Destroy(clone,1.5f);
    }
    public void StartDelay()
    {
        StartCoroutine(Delay());
    }


    public IEnumerator Delay()
    {
        anim.SetBool("Press", true);
        yield return new WaitForSecondsRealtime(0.2f);
        anim.SetBool("Press", false);
    }

}
