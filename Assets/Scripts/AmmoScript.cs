using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private GameObject bulletDecal;

    private float speed = 50f;
    private float timeToDestroy = 3f;

    //WHY THE HELL PROPERTIES INSTEAD OF NORMAL VARIABLES?
    public Vector3 Target { get; set; } //propertys with the Capital first letter
    public bool Hit { get; set; } //propertys with the Capital first letter

    private void OnEnable()
    {
        //bullt destoyed after instantiated the time variable timeToDestoy
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
        ContactPoint contact = collision.GetContact(0); // define variable contact to be first one on where it is contacted
        GameObject.Instantiate(bulletDecal, contact.point + contact.normal * .0001f, Quaternion.LookRotation(contact.normal));//contact is the point where the bullet hits first, defined later!
        //bullet destoyed on hit
        Destroy(gameObject);
    }
}
