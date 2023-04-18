using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Animator animator;

    [Header("Arrow")]
    public GameObject HandArrow;
    // Start is called before the first frame update
    void Start()
    {
        HandArrow.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void HandArrowActive()
    {
        HandArrow.gameObject.SetActive(true);
    }

    

    

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        animator.SetFloat("Strafe", x);
        animator.SetFloat("Forward", y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("aim", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("aim", false);
            animator.SetBool("shoot", true);
        }
        else
        {
            animator.SetBool("shoot", false);
        }
    }
}
