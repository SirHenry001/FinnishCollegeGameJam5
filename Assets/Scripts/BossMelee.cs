using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMelee : MonoBehaviour
{
    public Rigidbody rb;
    public float force;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        Invoke("Slash", 2f);
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
            hp.LoseHealth(5);

        }
    }
}

