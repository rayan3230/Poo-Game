using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Tilemaps;
using UnityEngine;

/*public class PlayerMovment : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public Animator anim;
    private int FaceDir = 1;
    private bool isKnockBack;
    public Player_combat player_Combat;


    private void Update()
    {
        if (Input.GetButtonDown("Slash"))
        {
            player_Combat.Attack();
        }
    //}


    //void FixedUpdate()
    //{
        if(isKnockBack == false)
        {
         float horizantal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                if(horizantal > 0 && transform.localScale.x<0 || horizantal <0 && transform.localScale.x > 0)
                {

                    Flip();
                }

                anim.SetFloat("HorizantalA", Mathf.Abs(horizantal));
                anim.SetFloat("VerticalA", Mathf.Abs(vertical));



                rb.velocity = new Vector2(horizantal , vertical) * StatsManager.Instance.speed;
        }
       

    }

    void Flip()
    {
        FaceDir *= -1;
        transform.localScale = new Vector3( transform.localScale.x * -1 ,transform.localScale.y , transform.localScale.z);
    }
    public void knockback(Transform enemy , float force , float stuntime)
    {
        isKnockBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.velocity = direction * force;
        StartCoroutine(KnockBackCounter(stuntime));
    }
    IEnumerator KnockBackCounter(float Stuntime)
    {
        yield return new WaitForSeconds(Stuntime);
        rb.velocity = Vector2.zero; 
        isKnockBack =false; 
    }
}

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private int FaceDir = 1;
    private bool isKnockBack;
    public Player_combat player_Combat;

    private void Start()
    {
        // Debug log for troubleshooting
        Debug.Log("PlayerMovement script initialized.");

        // Attempt to assign references automatically
        if (player_Combat == null)
        {
            player_Combat = GetComponent<Player_combat>();
            if (player_Combat == null)
                Debug.LogError("Player_combat component is missing! Assign it in the Inspector.");
        }

        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
                Debug.LogError("Rigidbody2D component is missing! Add one to the GameObject.");
        }

        if (anim == null)
        {
            anim = GetComponent<Animator>();
            if (anim == null)
                Debug.LogError("Animator component is missing! Add one to the GameObject.");
        }
    }

    private void Update()
    {
        if (player_Combat != null && Input.GetButtonDown("Slash"))
        {
            player_Combat.Attack();
        }

        if (!isKnockBack)
        {
            float horizantal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if ((horizantal > 0 && transform.localScale.x < 0) || (horizantal < 0 && transform.localScale.x > 0))
            {
                Flip();
            }

            if (anim != null)
            {
                anim.SetFloat("HorizantalA", Mathf.Abs(horizantal));
                anim.SetFloat("VerticalA", Mathf.Abs(vertical));
            }
            else
            {
                Debug.LogWarning("Animator is not assigned. Movement animations will not play.");
            }

            if (rb != null)
            {
                if (StatsManager.Instance != null)
                {
                    rb.velocity = new Vector2(horizantal, vertical) * StatsManager.Instance.speed;
                }
                else
                {
                    Debug.LogError("StatsManager.Instance is null! Ensure it is properly initialized.");
                }
            }
            else
            {
                Debug.LogError("Rigidbody2D is not assigned. Player cannot move.");
            }
        }
    }

    void Flip()
    {
        FaceDir *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void knockback(Transform enemy, float force, float stuntime)
    {
        isKnockBack = true;
        if (rb != null)
        {
            Vector2 direction = (transform.position - enemy.position).normalized;
            rb.velocity = direction * force;
        }
        else
        {
            Debug.LogError("Rigidbody2D is not assigned. Knockback cannot be applied.");
        }

        StartCoroutine(KnockBackCounter(stuntime));
    }

    IEnumerator KnockBackCounter(float Stuntime)
    {
        yield return new WaitForSeconds(Stuntime);
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
        isKnockBack = false;
    }
}*/

using UnityEngine.InputSystem; // Required for New Input System

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Player_combat player_Combat;

    private PlayerControls controls; // Input Actions class
    private Vector2 movementInput;   // Stores movement input
    private int faceDir = 1;         // For flipping the sprite
    private bool isKnockBack;        // Prevents movement during knockback

    private void Awake()
    {
        // Initialize the Input Actions
        controls = new PlayerControls();

        // Bind actions to methods
        controls.Player.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.Player.Movement.canceled += ctx => movementInput = Vector2.zero;
        controls.Player.Slash.performed += ctx => Attack();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Update()
    {
        if (!isKnockBack)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        // Use movement input
        float horizontal = movementInput.x;
        float vertical = movementInput.y;

        // Flip player sprite based on horizontal direction
        if ((horizontal > 0 && transform.localScale.x < 0) || (horizontal < 0 && transform.localScale.x > 0))
        {
            Flip();
        }

        // Set animation parameters
        if (anim != null)
        {
            anim.SetFloat("HorizantalA", Mathf.Abs(horizontal));
            anim.SetFloat("VerticalA", Mathf.Abs(vertical));
        }

        // Move the player
        if (rb != null && StatsManager.Instance != null)
        {
            rb.velocity = new Vector2(horizontal, vertical) * StatsManager.Instance.speed;
        }
    }

    private void Flip()
    {
        faceDir *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void Attack()
    {
        if (player_Combat != null)
        {
            player_Combat.Attack();
        }
    }

    public void knockback(Transform enemy, float force, float stuntime)
    {
        isKnockBack = true;

        if (rb != null)
        {
            Vector2 direction = (transform.position - enemy.position).normalized;
            rb.velocity = direction * force;
        }

        StartCoroutine(KnockBackCounter(stuntime));
    }

    private IEnumerator KnockBackCounter(float stuntime)
    {
        yield return new WaitForSeconds(stuntime);
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
        isKnockBack = false;
    }
}

