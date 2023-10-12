using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltGunAmmo : MonoBehaviour
{

    public Rigidbody rb;
    public float power;
    public float speed;
    public GameObject targetToStrike;
    public GameObject FX;

    Vector3 movement;

    Vector3 offSet = new Vector3(0, 0, 0);

    public bool isStriking;



    private void Start()
    {

        targetToStrike = GameObject.FindGameObjectWithTag("Enemy");

    }

    private void FixedUpdate()
    {

        Vector3 dir = (targetToStrike.transform.position - offSet) - transform.position;
        dir.Normalize();
        movement = dir;
        Hit(movement);
    }

    void Hit(Vector3 dir)
    {
        rb.MovePosition((Vector3)transform.position + (speed * Time.deltaTime * dir));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HealthScript hp = collision.gameObject.GetComponentInParent<HealthScript>();
            BossScript boss = collision.gameObject.GetComponentInParent<BossScript>();
            boss.anim.SetTrigger("Hitted");
            boss.SpawnHealthPickUp();
            Instantiate(FX, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            hp.LoseHealth(120);

        }
    }
}
