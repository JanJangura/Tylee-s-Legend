using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;   
    public Animator animator;

    public void TakeDamage(int damageAmount)
    {
        maxHealth -= damageAmount;

        if(maxHealth <= 0)
        {
            animationPlayDeath();
            GetComponent<Collider>().enabled = false;
            Debug.Log("Dead");
        }
        else
        {            
            animationDamageTaken();
            Debug.Log("GUN");
            Debug.Log(maxHealth);
        }
    }

    public virtual void animationPlayDeath()
    {
        animator.SetTrigger("die");
    }

    public virtual void animationDamageTaken()
    {
        animator.SetTrigger("damage");
    }
}
