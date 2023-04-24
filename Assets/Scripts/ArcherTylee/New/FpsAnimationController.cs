using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsAnimationController : MonoBehaviour
{
    Animator anim;

    int xmove = Animator.StringToHash("xmove");
    int ymove = Animator.StringToHash("ymove");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayerAnimation(Vector2 m)
    {
        anim.SetFloat(xmove, m.x);
        anim.SetFloat(ymove, m.y);
    }
}
