using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public float minPosX;
    public float maxPosX;
    public float minPosZ;
    public float maxPosZ;

    public float variationTimer;

    private void Awake()
    {
        InvokeRepeating("LocationVariation", 0f, variationTimer);
    }

    public void LocationVariation()
    {
        gameObject.transform.position = new Vector3((Random.Range(minPosX, maxPosX)), transform.position.y, (Random.Range(minPosZ, maxPosZ)));
    }

}
