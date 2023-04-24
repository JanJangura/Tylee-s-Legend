using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float cameraSens = 5f;

    [SerializeField] float clampRotation = 80f;

    [SerializeField] Transform headPos = null;

    [SerializeField] Transform cam = null;

    FpsControllerinput fpsControllerinput;

    FpsAnimationController fpsAnimation;

    Rigidbody rb;

    float mousex;

    private void Awake()
    {
        fpsControllerinput = GetComponent<FpsControllerinput>();
        fpsAnimation = GetComponent<FpsAnimationController>();
        rb = GetComponentInChildren<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        LookAround();
    }

    private void FixedUpdate()
    {
        if (fpsControllerinput.GetMoveAxis().magnitude > 0)
        {
           rb.velocity = transform.forward * fpsControllerinput.GetMoveAxis().y * moveSpeed +
                         transform.right * fpsControllerinput.GetMoveAxis().x * moveSpeed
                         + transform.up * rb.velocity.y;
        }
        else if(rb.velocity.z != 0 || rb.velocity.x != 0)
        {
            rb.velocity = Vector3.up * rb.velocity.y;   
        }

        fpsAnimation.PlayerAnimation(fpsControllerinput.GetMoveAxis());
    }

    void LookAround()
    {
        cam.position = headPos.position;
        mousex -= fpsControllerinput.GetMouseAxis().y;
        cam.localRotation = Quaternion.Euler(Mathf.Clamp(mousex * cameraSens,-clampRotation,clampRotation), 0, 0);

        transform.Rotate(transform.up, fpsControllerinput.GetMouseAxis().x * cameraSens);
    }
}
