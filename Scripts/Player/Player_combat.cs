using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_combat : MonoBehaviour
{
    public Animator anim;
    
    public Transform attackpointe;
    public float cooldown=1;
    public LayerMask enemyLayer;
  

    private float timer;

    public void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        if( timer <= 0)
        {
            anim.SetBool("isAttacking" , true);
            timer = cooldown;

        }
        
    }

    public void DealDAmage()
    {
       
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackpointe.position, StatsManager.Instance.weaponRange, enemyLayer);
        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(StatsManager.Instance.damage);
            enemies[0].GetComponent<Enemy_KnockBack>().KnockBack(transform , StatsManager.Instance.KnockPower , StatsManager.Instance.KnockbackTime,StatsManager.Instance.stuntime);
        }
    }
    public void finishAttacking()
    {
        anim.SetBool("isAttacking",false);
    }
}
