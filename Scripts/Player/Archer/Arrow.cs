using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 direction;
    public float lifespawn = 2;
    public float speed;
    public LayerMask enemylayer;
    public LayerMask Obstaclelayer;
    public SpriteRenderer sr;
    public Sprite buriedArrow;

    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;
    void Start()
    {
        rb.velocity = direction * speed;
        RotateArrow();
        Destroy(gameObject , lifespawn);
    }
    private void RotateArrow() // to rotate the arrow when it was shoot
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((enemylayer.value & (1 << collision.gameObject.layer)) > 0) 
        {
            Enemy_Health enemyHealth = collision.gameObject.GetComponent<Enemy_Health>();
            if (enemyHealth != null)
            {
                enemyHealth.ChangeHealth(StatsManager.Instance.Arrowdamage);
            }
            collision.gameObject.GetComponent<Enemy_Health>().ChangeHealth(StatsManager.Instance.Arrowdamage);

            collision.gameObject.GetComponent<Enemy_KnockBack>().KnockBack(transform, knockbackForce, knockbackTime, stunTime);
            AttacheToTarget(collision.gameObject.transform);


        }
        else if((Obstaclelayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            AttacheToTarget(collision.gameObject.transform);
        }
    }
    private void AttacheToTarget(Transform target)
    {
        sr.sprite = buriedArrow;//change the sprite
        rb.velocity =  Vector3.zero ;
        rb.isKinematic = true; // to not react to collosion etc 

        transform.SetParent(target);
    }

}
