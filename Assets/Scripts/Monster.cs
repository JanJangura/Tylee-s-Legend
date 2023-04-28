using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : Nightmare
{
    public override void Start()
    {
            WP = GameObject.FindGameObjectWithTag("WavePoints").GetComponent<WavePoints>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

            agent = this.gameObject.GetComponent<NavMeshAgent>();
            animator = this.gameObject.GetComponent<Animator>();
    }
}
