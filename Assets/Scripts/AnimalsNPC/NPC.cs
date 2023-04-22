using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    WavePoints WP;

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
        if (agent.remainingDistance <= 1 && agent.remainingDistance > 0)
        {
            Invoke("MoveAI", 1);
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
    }

    public void MoveAI()
    {       
        int rand = Random.Range(0, WP.wavePoints.Length);
        agent.SetDestination(WP.wavePoints[rand].position);
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
    }
}
