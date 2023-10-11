using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Press" && StateManager.instance.state == StateManager.LevelState.ChanceForMelt)
        {
            StateManager.instance.state = StateManager.LevelState.MeltMode;
        }
    }
}
