using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Ability : MonoBehaviour
{
    //PLAYER CORE COMPONENT
    public PlayerCore core;

    //MOVEMENT VARIABLES
    public Vector2 mouseVector;
    public float playerSpeed;

    //LOOK VARIABLES
    public float sensitivity = 100f;
    private void Update()
    {
        //LookMouse();
    }

    public void Movement(Vector2 value)
    {
        //core.rb.velocity = new Vector3(core.rb.velocity.x, core.rb.velocity.y, core.rb.velocity.z);

        if(value.y > 0 || value.y < 0)
        {
            core.rb.position += transform.forward * value.y * Time.deltaTime * playerSpeed;
        }
        if (value.x > 0 || value.x < 0)
        {
            core.rb.position += transform.right * value.x * Time.deltaTime * playerSpeed;
        }

        core.rb.velocity.Normalize();
    }

    public void LookMouse()
    {
        //MOUSE INPUT
        mouseVector.x += Input.GetAxis("Mouse X");
        mouseVector.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-mouseVector.y, mouseVector.x, 0);
    }

    public void LookGamePad(Vector2 value)
    {
        transform.localRotation = Quaternion.Euler(Vector3.right * value.x * 10000f);
        transform.localRotation = Quaternion.Euler(Vector3.up * value.y * 10000f);
    }


}
