using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nightmare : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;   
    public Animator animator;

    public NavMeshAgent agent;
    WavePoints WP;

    public virtual void Start()
    {
        WP = GameObject.FindGameObjectWithTag("WavePoints").GetComponent<WavePoints>();

        agent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();

        MoveAI();
    }

    public virtual void Update()
    {
        AImovement();
    }

    public void TakeDamage(int damageAmount)
    {
        maxHealth -= damageAmount;

        if(maxHealth <= 0)
        {
            animationPlayDeath();
            GetComponent<Collider>().enabled = false;
        }
        else
        {            
            animationDamageTaken();
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

    public virtual void AImovement()
    {
        if (agent.remainingDistance < 1 && agent.remainingDistance > 0)
        {
            Invoke("MoveAI", 1);
        }
    }

    public virtual void MoveAI()
    {
        int rand = Random.Range(0, WP.wavePoints.Length);
        agent.SetDestination(WP.wavePoints[rand].position);
    }
}
