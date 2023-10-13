using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private GameObject bulletDecal;
    public GameObject spawnPos;

    public float speed = 50f;
    public float timeToDestroy = 3f;

    public Vector3 Target { get; set; }
    public bool Hit { get; set; }

    private void OnEnable()
    {
        //bullet destoyed after instantiated the time variable timeToDestoy
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {

        //Bullet direction and speed
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);

        // if bullet DOES NOT hit anything and also bullet get close to the defined target, destroy bullet
        if (!Hit && Vector3.Distance(transform.position, Target) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HealthScript hp = collision.gameObject.GetComponentInParent<HealthScript>();
            GameObject clone = Instantiate(bulletDecal, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(clone,1.5f);
            hp.LoseHealth(5);

        }

        if (collision.gameObject.tag == "EnemyShort")
        {
            BossMelee melee = collision.gameObject.GetComponentInParent<BossMelee>();
            GameObject clone = Instantiate(bulletDecal, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(clone, 1.5f);
            melee.LoseDurability(1);

        }

        //ContactPoint contact = collision.GetContact(0); // define variable contact to be first one on where it is contacted
        //GameObject.Instantiate(bulletDecal, contact.point + contact.normal * .0001f, Quaternion.LookRotation(contact.normal));//contact is the point where the bullet hits first, defined later!
        //bullet destoyed on hit
        Destroy(gameObject);
    }
}
