using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear : Nightmare
{  
    public GameObject meat;
    public int damage = 1;
    bool isRunning;
    bool isDeath;
    public float deathTimer = 5f;
    public float stopRunning = 7f;

    public override void Start()
    {
        base.Start();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            GoRun();
            base.TakeDamage(damage);
            player.isBear = true;
        }
    }

    void GoRun()
    {
        isRunning = true;
        Invoke("StopRunning", stopRunning);
    }

    void StopRunning()
    {
        isRunning = false;
    }

    public override void animationPlayDeath()
    {
        isDeath = true;
        player.isBear = true;
        isRunning = false;
        agent.speed = 0;
        Invoke("Destruction", deathTimer);
        Debug.Log("DEATH");
    }

    public void Destruction()
    {
        Destroy(this.gameObject);
        Instantiate(meat, this.transform.position, Quaternion.identity);
    }

    public override void animationDamageTaken()
    {
        Debug.Log("Hit");
    }

    public override void AImovement()
    {
        if (agent.remainingDistance < 1 && agent.remainingDistance > 0)
        {
            base.Invoke("MoveAI", 1);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }
        else
        {
            if (isRunning)
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", true);
                agent.speed = 12;
            }
            else if (isDeath)
            {
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsDead", true);
            }
            else
            {
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsWalking", true);
                agent.speed = 3;
            }
        }
    }
}
