using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public float rayCastRange = 1f;
    public LayerMask layermask;
    public float heal = 5;
    PlayerHealth playerHealth;
    public GameObject PickUpUI;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!PauseMenu.isPaused)
        //{
        //    RayCastTool();
        //}

        RayCastTool();
    }

    void RayCastTool()
    {
        Vector3 direction = Vector3.forward;
        Ray ray = new Ray(transform.position, transform.TransformDirection(direction * rayCastRange));
        Debug.DrawRay(transform.position, transform.forward * rayCastRange, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayCastRange, layermask)) // This gives a raycast to the game object position.
        {
            switch (hitInfo.collider.tag)
            {
                case "ObjectInteraction":
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PickUpItem(hitInfo);
                    }
                    return;

                default: return;
            }
        }
    }   

    void PickUpItem(RaycastHit hitInfo)
    {
        Destroy(hitInfo.transform.gameObject);
        playerHealth.health += heal;
    }

    void DisplayMessage()
    {
        PickUpUI.SetActive(true);
    }
}
