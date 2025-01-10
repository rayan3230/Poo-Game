using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;
    public int EXPWorth = 3;
    public int currentHp;
    public int Maxhealth ;
    public Animator animator;

    private void Start()
    {
        currentHp = Maxhealth;
    }
    public void Update()
    {
        
    }
    public void ChangeHealth(int amount)
    {
        currentHp -= amount;
        if (currentHp > Maxhealth)
        {
            currentHp = Maxhealth;
        }
        else if (currentHp <= 0) 
        { 
            OnMonsterDefeated(EXPWorth);
            Death();
        }
    }
    public void Death()
    {
       
        animator.SetBool("isdead", true); // Trigger death animation
        Debug.Log("The enemy  is dead");
        // Delay destruction to allow animation to finish
        StartCoroutine(DestroyAfterDelay(2f)); // Adjust the delay as needed
    }
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
