using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Archer_Bow : MonoBehaviour
{
    [Header("Bow Stats")]
    public Transform BowDirection;

    [Header("Arrow Stats")]
    public float shootCooldown = 1;
    public Transform playerDir;
    public Animator anim;
    public Transform launchPoint;
    public GameObject arrowPrefab;

    private Vector2 moveInput; // Stores movement input from the player
    private Vector2 aimDirection = Vector2.right; // Default aiming direction
    private float shootTimer;

    private ArcherInputActions inputActions;

    private void Awake()
    {
        // Initialize the input system
        inputActions = new ArcherInputActions();

        // Subscribe to input events
        inputActions.Archer.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Archer.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Archer.Shoot.performed += ctx => Shoot();
    }

    private void OnEnable()
    {
        // Enable the input actions
        inputActions.Archer.Enable();
    }

    private void OnDisable()
    {
        // Disable the input actions
        inputActions.Archer.Disable();
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;

        HandleAiming();
        BowPosition();
    }

    private void BowPosition()
    {
        // Check if there's input to determine direction
        if (moveInput != Vector2.zero)
        {
            // Calculate the angle in degrees for the direction
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;

            // Rotate the bow to point in the direction
            BowDirection.rotation = Quaternion.Euler(0, 0, angle);

            // Flip the bow sprite or scale for left/right
            if (moveInput.x < 0)
            {
                BowDirection.localScale = new Vector3(-1, 1, 1); // Flip horizontally
            }
            else if (moveInput.x > 0)
            {
                BowDirection.localScale = new Vector3(1, 1, 1); // Normal orientation
            }
        }
    }

    private void HandleAiming()
    {
        if (moveInput != Vector2.zero)
        {
            if (playerDir.localScale.x >= 0)
            {
                aimDirection = moveInput.normalized;
            }
            else if (playerDir.localScale.x < 0)
            {
                aimDirection = new Vector2(-moveInput.x, moveInput.y).normalized;
            }
        }
    }

    public void Shoot()
    {
        if (shootTimer > 0) return;

        // Instantiate the arrow at the launch point
        Arrow arrow = Instantiate(arrowPrefab, launchPoint.position, Quaternion.identity).GetComponent<Arrow>();

        // Trigger the shooting animation
        anim.SetTrigger("shoot");

        // Check if the player is facing right or left and set the arrow's scale and direction accordingly
        if (playerDir.localScale.x > 0) // Player facing right
        {
            arrow.transform.localScale = new Vector3(1, arrow.transform.localScale.y, 1); // Arrow facing right
            arrow.direction = aimDirection; // Set the direction based on the aiming direction
        }
        else if (playerDir.localScale.x < 0) // Player facing left
        {
            arrow.transform.localScale = new Vector3(1, arrow.transform.localScale.y, 1); // Flip arrow horizontally
            arrow.direction = new Vector2(-aimDirection.x, aimDirection.y); // Flip only the X direction of the arrow's aim
        }

        // Reset the shoot cooldown timer
        shootTimer = shootCooldown;
    }

    public void NotShoot()
    {
        anim.SetBool("notshoot", true);
    }
}


