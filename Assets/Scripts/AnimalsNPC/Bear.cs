using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear : Nightmare
{
    NavMeshAgent agent;
    WavePoints WP;
    public GameObject meat;
    public int damage = 1;
    bool isRunning;
    bool isDeath;
    public float deathTimer = 5f;
    public float stopRunning = 7f;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
        WP = GameObject.FindGameObjectWithTag("WavePoints").GetComponent<WavePoints>();
        MoveAI();
    }

    private void Update()
    {
        if (agent.remainingDistance < 1 && agent.remainingDistance > 0)
        {
            Invoke("MoveAI", 1);
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

    public void MoveAI()
    {
        int rand = Random.Range(0, WP.wavePoints.Length);
        agent.SetDestination(WP.wavePoints[rand].position);
    }

    /// ////////////////////////////////////////////

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            GoRun();
            base.TakeDamage(damage);
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
}
