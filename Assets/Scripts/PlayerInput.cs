using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [Header("Input System & Vector")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Vector2 moveVector;
    [SerializeField] private Vector2 mouseVector;

    [Header("Input Actions")]
    private InputAction mouseInput;
    private InputAction moveInput;
    private InputAction jumpInput;
    private InputAction shootInput;
    private InputAction dashInput;

    [Header("Player Scripts")]
    public PlayerCore core;
    public Move_Ability moveAbility;
    public Jump_Ability jumpAbility;
    public Shoot_Ability shootAbility;
    public Dash_Ability dashAbility;

    private void Awake()
    {
        playerController = new PlayerController();
        mouseInput = playerController.Player.LookPad;
        moveInput = playerController.Player.Move;
        jumpInput = playerController.Player.Jump;
        shootInput = playerController.Player.Shoot;
        dashInput = playerController.Player.Dash;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        //BASIC CONTROLS INPUT PRESSED
        jumpInput.performed += DoJump;
        shootInput.performed += DoShoot;
        dashInput.performed += DoDash;
        //BASIC CONTROLS INPUT PRESSED
        jumpInput.canceled += CancelJump;


        //ENABLE INPUTS
        mouseInput.Enable();
        moveInput.Enable();
        jumpInput.Enable();
        shootInput.Enable();
        dashInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
        mouseInput.Disable();
        jumpInput.Disable();
        shootInput.Disable();
        dashInput.Disable();
    }

    // LINKS TO ABILITY MOVEMENT
    private void FixedUpdate()
    {
        moveVector = moveInput.ReadValue<Vector2>();
        moveAbility.Movement(moveVector);

        /*
        mouseVector = mouseInput.ReadValue<Vector2>();
        moveAbility.LookGamePad(mouseVector);
        */

        shootAbility.LookFinal();

        
    }
    // (BUTTON PRESS) LINKS TO ABILITY FUNCTIONS TO SCRIPTS
    private void DoJump(InputAction.CallbackContext obj)
    {
        jumpAbility.Jump();
        core.jumpPressed = true;
    }
    private void DoShoot(InputAction.CallbackContext obj)
    {
        shootAbility.Shoot();
    }
    private void DoDash(InputAction.CallbackContext obj)
    {
        dashAbility.Dash();
    }

    // (BUTTON CANCEL) LINKS TO ABILITY FUNCTIONS TO SCRIPTS
    private void CancelJump(InputAction.CallbackContext obj)
    {
        core.jumpPressed = false;
    }
}
