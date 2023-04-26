using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHealth : MonoBehaviour
{
    public GameObject player;

    public float health = 100f;

    void Start()
    {
      
    }

    void Update()
    {

        if (health <= 0)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (health > 100)
        {
            health = 100;
        }
    }
}
