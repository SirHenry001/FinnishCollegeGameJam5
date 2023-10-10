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
    public float rotationSpeed;

    //LOOK VARIABLES
    public float sensitivity = 100f;
    private void Update()
    {
        RotatePlayerTowardsCamera();
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
    public void RotatePlayerTowardsCamera()
    {
        float targetAngle = core.cameraTransform.eulerAngles.y; // give the targetAngle the axis y rotation angle towards cmaeraTransfrom
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0); // internal variable targetrotation which defines the axis where to rotate based on targetAngle
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Rotate the PLayer between two points and certain rotationSpeed variable
    }

    /*
    public void LookMouse()
    {
        //MOUSE INPUT
        mouseVector.x += Input.GetAxis("Mouse X");
        mouseVector.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-mouseVector.y, mouseVector.x, 0);
    }
    */

}
