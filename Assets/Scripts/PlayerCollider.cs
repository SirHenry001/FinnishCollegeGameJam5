using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject fx;
    public GameObject spawnPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Press" && StateManager.instance.state != StateManager.LevelState.ChanceForMelt)
        {
            Debug.Log("Osun");
            other.gameObject.GetComponentInParent<ButtonScript>().StartDelay();
        }

        if (other.gameObject.tag == "Press" && StateManager.instance.state == StateManager.LevelState.ChanceForMelt)
        {
            Debug.Log("Osun");
            spawnPos = other.gameObject.GetComponentInParent<ButtonScript>().spawnPos.gameObject;
            GameObject clone = Instantiate(fx, spawnPos.transform.position, spawnPos.transform.rotation);
            StateManager.instance.state = StateManager.LevelState.MeltMode;
            Destroy(clone, 3f);
            
        }
    }

}
