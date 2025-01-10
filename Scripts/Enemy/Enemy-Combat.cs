using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EnemyCombat : MonoBehaviour
{
    public int Damage;
    public Transform attackpointe;
    public float weaponerange;
    public float knockbackforce;
    public float stunetime;
    public LayerMask playerlayer;
    
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>().ChangeHp(Damage);
    }*/
    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackpointe.position ,weaponerange ,playerlayer);
        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHp(Damage);
            hits[0].GetComponent<PlayerMovement>().knockback(transform,knockbackforce,stunetime);


        }
    }
}
