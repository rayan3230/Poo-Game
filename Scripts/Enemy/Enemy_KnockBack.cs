using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy_Mov;

public class Enemy_KnockBack : MonoBehaviour
{
    private Rigidbody2D rb;
    private Enemy_Mov Enemy_Mov;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Enemy_Mov = GetComponent<Enemy_Mov>();
    }

    public void  KnockBack(Transform forcetransform , float KnockbackPower ,float KnockbackTime,float stuntime)
    {
        Enemy_Mov.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(KnockbackTime,stuntime));
        Vector2 direction = (transform.position - forcetransform.position).normalized;
        rb.velocity = direction * KnockbackPower;

    }
    IEnumerator StunTimer(float knockbacktime,float stuntime)
    {
        yield return new WaitForSeconds(knockbacktime);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(stuntime);
        Enemy_Mov.ChangeState(EnemyState.Idle);
    }
}
