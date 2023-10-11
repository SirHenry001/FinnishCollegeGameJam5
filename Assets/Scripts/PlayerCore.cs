using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    //COMPONENT VARIABLES
    public Rigidbody rb;
    public Camera mainCamera;
    public Transform cameraTransform;
    public Animator anim;


    // BOOLEANS FOR PLAYER STATE
    public bool isGrounded;
    public bool jumpPressed;
    public bool isDashing;
    public bool shootCoolDown;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        cameraTransform = Camera.main.transform;
    }
}
