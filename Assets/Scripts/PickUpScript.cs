using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Health pick Up");
            HealthScriptPlayer hp = other.gameObject.GetComponentInParent<HealthScriptPlayer>();
            hp.healthAmount += 25;
            MenuManager menu = GameObject.Find("MENUMANAGER").GetComponent<MenuManager>();
            menu.healthBarPlayer.fillAmount = hp.healthAmount;
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb.AddForce(transform.forward * 500f);
        Destroy(gameObject, 20f);
    }

}
