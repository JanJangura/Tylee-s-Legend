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

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            isRunning = true;
            base.TakeDamage(damage);
        }
    }

    void GoRun()
    {
        Invoke("StopRunning", 10);
    }

    void StopRunning()
    {
        isRunning = false;
    }

    public override void animationPlayDeath()
    {
        Destroy(this.gameObject);
        Instantiate(meat, this.transform.position, Quaternion.identity);
        Debug.Log("DEATH");
    }

    public override void animationDamageTaken()
    {
        Debug.Log("Hit");
    }
}
