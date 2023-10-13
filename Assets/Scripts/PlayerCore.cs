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

    private void Awake()
    {
        GameManager.Success += WinAnim;
        GameManager.Fail += LoseAnim;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        cameraTransform = Camera.main.transform;
    }

    public void WinAnim()
    {
        anim.SetTrigger("WinTrig");
    }
    public void LoseAnim()
    {
        anim.SetTrigger("LoseTrig");
    }
}
