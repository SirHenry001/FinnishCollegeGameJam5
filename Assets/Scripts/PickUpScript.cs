using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject fx;
    public GameObject spawnPos;

    public float appearTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject clone = Instantiate(fx, spawnPos.transform.position, spawnPos.transform.rotation);
            Destroy(clone, 3.5f);
            HealthScriptPlayer hp = other.gameObject.GetComponentInParent<HealthScriptPlayer>();
            hp.healthAmount += 25;
            
            if(hp.healthAmount >= 100)
            {
                hp.healthAmount = 100;
            }
            
            MenuManager menu = GameObject.Find("MENUMANAGER").GetComponent<MenuManager>();
            menu.healthBarPlayer.fillAmount = hp.healthAmount;
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb.AddForce(transform.forward * 500f);
        Destroy(gameObject, appearTime);
    }

}
