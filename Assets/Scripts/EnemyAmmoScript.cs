using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoScript : MonoBehaviour
{
    public Rigidbody rb;
    public float power;
    public float speed;
    public GameObject targetToStrike;
    public GameObject FX;


    public bool startToTarget;

    Vector3 movement;

    private void Start()
    {
        startToTarget = false;
        StartCoroutine(AmmoFunction());
    }

    

    IEnumerator AmmoFunction()
    {
        rb.AddForce(transform.forward * power, ForceMode.Impulse);
        yield return new WaitForSeconds(2f);

        targetToStrike = GameObject.FindGameObjectWithTag("Lock");

        startToTarget = true;

        Destroy(gameObject, 2f);

    }

    private void FixedUpdate()
    {
        if(startToTarget)
        {
            rb.velocity = Vector3.zero;
            Vector3 dir = targetToStrike.transform.position - transform.position;
            dir.Normalize();
            movement = dir;
            Hit(movement);
        }
    }

    void Hit(Vector3 dir)
    {
        rb.MovePosition((Vector3)transform.position + (dir * speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthScriptPlayer hp = collision.gameObject.GetComponent<HealthScriptPlayer>();

            hp.LoseHealth(5);
            Instantiate(FX, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Lock")
        {
            Instantiate(FX, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(gameObject);

        }


    }
}
