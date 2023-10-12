using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMelee : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public int durability;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6.5f);
        Invoke("Slash", 3.5f);
    }

    public void Slash()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(-transform.up * force, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthScriptPlayer hp = collision.gameObject.GetComponent<HealthScriptPlayer>();
            hp.LoseHealth(10);

        }
    }
    
    public void LoseDurability(int damage)
    {
        damage -= durability;
        if(durability <= 0)
        {
            Destroy(gameObject);
        }
    }
}

