using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Ability : MonoBehaviour
{
    //PLAYER CORE COMPONENT
    public PlayerCore core;


    public GameObject groundCheckObj;
    public float jumpPower = 250f;
    public float fallMultiplier = 80f;
    public float lowJumpMultiplier = 80f;


    //GROUND CHECK VARIABLES
    public float detectRadius = 1f;
    public float y;

    //LAYERMASK VARIABLES
    public LayerMask groundMask;
    public LayerMask interactMask;

    private void Update()
    {
        GroundCheck();
        GravityCheck();
    }
    void GroundCheck()
    {
        RaycastHit hit;

        Vector3 dir = new Vector3(0, -1);

        if(Physics.Raycast(transform.position, dir, out hit, detectRadius, groundMask))
        {
            Debug.DrawRay(transform.position, dir, Color.green);
            core.isGrounded = true;
        }
        else
        {
            Debug.DrawRay(transform.position, dir, Color.green);
            core.isGrounded = false;
        }

    }
    public void GravityCheck()
    {
        y = core.rb.velocity.y;

        // PLAYER GRAVITY MULTIPLIES DURING FALLING
        if (y < 0)
        {
            core.rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
        }
        /*
        // IF JUMP BUTTON IS RELEASED DURING JUMP, PLAYER FALL DOWN FASTER AND GET SMALLER JUMP
        else if (y > 0 && !core.jumpPressed)
        {
            core.rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1f) * Time.deltaTime;
        }
        */

    }
    public void Jump()
    {
        if (core.isGrounded == true)
        {
            core.anim.SetBool("Jump", true);
            core.rb.velocity = Vector2.up * jumpPower;
            //core.rb.AddForce(transform.up * jumpPower);
        }
    }
    public void AnimActivationOff()
    {
        core.anim.SetBool("Jump", false);
    }

}
