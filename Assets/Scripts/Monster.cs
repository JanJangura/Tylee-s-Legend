using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : Nightmare
{
    public override void AImovement()
    {
        
    }
    public override void MoveAI()
    {
        
    }

    public override void Update()
    {

    }

    public override void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
    }
}
