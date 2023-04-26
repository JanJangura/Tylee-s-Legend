using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Rendering.HighDefinition;

public class PlayerDetection : MonoBehaviour
{
    public float rayCastRange = 1f;
    public LayerMask layermask;
    public float heal = 5;
    PlayerHealth playerHealth;

    [Header("Canvas UI")]
    public TextMeshProUGUI PickUpUIText;
    public bool pickUpActive;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.isPaused == false)
        {
            RayCastTool();
        }
        Prompt();
    }

    void RayCastTool()
    {
        Vector3 direction = Vector3.forward;
        Ray ray = new Ray(transform.position, transform.TransformDirection(direction * rayCastRange));
        Debug.DrawRay(transform.position, transform.forward * rayCastRange, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayCastRange, layermask)) // This gives a raycast to the game object position.
        {
            if(hitInfo.collider != null)
            {
                switch (hitInfo.collider.tag)
                {
                    case "ObjectInteraction":
                        DisplayMessage();
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            PickUpItem(hitInfo);
                        }
                        return;

                    case null:
                        DisplayMessageOff();
                        return;

                    default:
                        DisplayMessageOff();
                        return;
                }
            }
        }
        else
        {
            DisplayMessageOff();
        }
    }   

    void PickUpItem(RaycastHit hitInfo)
    {
        Destroy(hitInfo.transform.gameObject);
        playerHealth.HealSelf((int)heal);
        DisplayMessageOff();
    }

    void DisplayMessage()
    {
        pickUpActive = true;
    }

    void DisplayMessageOff()
    {
        pickUpActive = false;
    }

    void Prompt()
    {
        if (!pickUpActive)
        {
            PickUpUIText.text = "";
        }
        else
        {
            PickUpUIText.text = "Press E";
        }
    }
}
