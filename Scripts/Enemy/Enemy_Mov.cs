using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.XR;

/*public class Enemy_Mov : MonoBehaviour
{   
    public float rangeAttack = 2;
    public float Speed;
    public float attackCooldown = 2;
    public float playerDetectRange = 5;
    public LayerMask playerlayer;
    public Transform detectionpoint;

    private float attackCooldownTimer;
    private Rigidbody2D rb;
    private Transform Player;
    private int Face_dir =-1;
    private EnemyState StateEnemy;
    private Animator animator;
    
    
    
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();// automatique yjib ll componnet li ykon f spirat
        animator = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }



    // Update is called once per frame
    void Update()
    {
        if(StateEnemy != EnemyState.Knockback)
        {
            CheckForPlayer();
            if (attackCooldownTimer > 0)

                attackCooldownTimer -= Time.deltaTime;

            if (StateEnemy == EnemyState.Chasing)

                chase();
            else if (StateEnemy == EnemyState.Attacking)
                rb.velocity = Vector3.zero;
        }
       
    }
            
        


        public void chase()
        {

             if ((Player.position.x > transform.position.x && Face_dir == -1) ||
                    (Player.position.x < transform.position.x && Face_dir == 1))
            {
                Flip();
            }
            Vector2 direction = (Player.position - transform.position).normalized;// calculate the path from the enemy to th player
            rb.velocity = direction * Speed;
        }

        
    
    private void CheckForPlayer()
    {

        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionpoint.position, playerDetectRange, playerlayer);
            if (hits.Length > 0) 
            { 
                    Player = hits[0].transform;
            //
                if (Vector2.Distance(transform.position, Player.position) <= rangeAttack && attackCooldownTimer <= 0)
                {
                    attackCooldownTimer = 0;
                    ChangeState(EnemyState.Attacking);

                } else if (Vector2.Distance(transform.position, Player.position) > rangeAttack && StateEnemy !=EnemyState.Attacking) { 
                    ChangeState(EnemyState.Chasing);
                }
               
             }
            else
            {
                rb.velocity = Vector2.zero;//stoping the player after running away
                ChangeState(EnemyState.Idle); 
                
            }
    
            
                
            }
    
    
  

     void Flip()
    {
        Face_dir *= -1;
        /*Vector3 newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * Face_dir;
        transform.localScale = newScale;
        transform.localScale = new Vector3( transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    public void ChangeState(EnemyState newState)
    {
        if (StateEnemy == EnemyState.Idle)
            animator.SetBool("isIdle",false);
        else if(StateEnemy== EnemyState.Chasing)
            animator.SetBool("isMoving",false );
        else if (StateEnemy == EnemyState.Attacking)
            animator.SetBool("isAttacking", false);


        StateEnemy = newState;
        if (StateEnemy == EnemyState.Idle)
            animator.SetBool("isIdle", true);
        else if (StateEnemy == EnemyState.Chasing)
            animator.SetBool("isMoving", true);
        else if (StateEnemy == EnemyState.Attacking)
            animator.SetBool("isAttacking", true);//isAttacking


    }

    public enum EnemyState
    {
        Idle,
        Chasing,
        Attacking,
        Knockback,
    }
}
*/


public class Enemy_Mov : MonoBehaviour
{
    public float rangeAttack = 2;
    public float Speed;
    public float attackCooldown = 2;
    public float playerDetectRange = 5;
    public LayerMask playerlayer;
    public Transform detectionpoint;

    private float attackCooldownTimer;
    private Rigidbody2D rb;
    private Transform Player;
    private int Face_dir = -1;
    private EnemyState StateEnemy;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    void Update()
    {
        if (StateEnemy != EnemyState.Knockback)
        {
            CheckForPlayer();
            if (attackCooldownTimer > 0)
                attackCooldownTimer -= Time.deltaTime;

            if (StateEnemy == EnemyState.Chasing)
                chase();
            else if (StateEnemy == EnemyState.Attacking)
                rb.velocity = Vector3.zero;
        }
    }

    public void chase()
    {
        if ((Player.position.x > transform.position.x && Face_dir == -1) ||
            (Player.position.x < transform.position.x && Face_dir == 1))
        {
            Flip();
        }
        Vector2 direction = (Player.position - transform.position).normalized;
        rb.velocity = direction * Speed;
    }

    private void CheckForPlayer()
    {
        Collider2D closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D hit in Physics2D.OverlapCircleAll(detectionpoint.position, playerDetectRange, playerlayer))
        {
            float distance = Vector2.Distance(transform.position, hit.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = hit;
            }
        }

        if (closestPlayer != null)
        {
            Player = closestPlayer.transform;

            if (Vector2.Distance(transform.position, Player.position) <= rangeAttack && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, Player.position) > rangeAttack && StateEnemy != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    void Flip()
    {
        Face_dir *= -1;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    public void ChangeState(EnemyState newState)
    {
        if (StateEnemy == EnemyState.Idle)
            animator.SetBool("isIdle", false);
        else if (StateEnemy == EnemyState.Chasing)
            animator.SetBool("isMoving", false);
        else if (StateEnemy == EnemyState.Attacking)
            animator.SetBool("isAttacking", false);

        StateEnemy = newState;

        if (StateEnemy == EnemyState.Idle)
            animator.SetBool("isIdle", true);
        else if (StateEnemy == EnemyState.Chasing)
            animator.SetBool("isMoving", true);
        else if (StateEnemy == EnemyState.Attacking)
            animator.SetBool("isAttacking", true);
    }

    public enum EnemyState
    {
        Idle,
        Chasing,
        Attacking,
        Knockback,
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionpoint.position, playerDetectRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }
}

