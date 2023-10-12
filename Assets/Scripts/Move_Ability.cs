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
    public float walkingSpeed;
    public float airSpeed;
    public float dashSpeed;
    public float rotationSpeed;

    // boundaries variables where player can move
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    //LOOK VARIABLES
    public float sensitivity = 100f;
    private void Update()
    {
        if(StateManager.instance.levelActive)
        {
            RotatePlayerTowardsCamera();
        }

    }

    public void Movement(Vector2 value)
    {
        //core.rb.velocity = new Vector3(core.rb.velocity.x, core.rb.velocity.y, core.rb.velocity.z);
        PlayerBoundaries();

        core.anim.SetFloat("x", value.x);
        core.anim.SetFloat("y", value.y);

        if(value.y > 0 || value.y < 0)
        {
            core.rb.position += transform.forward * value.y * Time.deltaTime * playerSpeed;
        }
        if (value.x > 0 || value.x < 0)
        {
            core.rb.position += transform.right * value.x * Time.deltaTime * playerSpeed;
        }

        if (core.isGrounded)
        {
            playerSpeed = walkingSpeed;
        }
        else if (core.isGrounded == false)
        {
            playerSpeed = airSpeed;
        }



        core.rb.velocity.Normalize();
    }
    public void RotatePlayerTowardsCamera()
    {
        float targetAngle = core.cameraTransform.eulerAngles.y; // give the targetAngle the axis y rotation angle towards cmaeraTransfrom
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0); // internal variable targetrotation which defines the axis where to rotate based on targetAngle
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Rotate the PLayer between two points and certain rotationSpeed variable
    }

    public void PlayerBoundaries()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y,Mathf.Clamp(transform.position.z, minY, maxY));
    }

}
