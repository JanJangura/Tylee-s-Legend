using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player;
    PlayerHealthBar healthBar;

    public float health = 100f;
    public int maxHealth;

    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<PlayerHealthBar>();
        maxHealth = (int)health;
        healthBar.SetMaxHealth(maxHealth);
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

    public void damageTaken(int i)
    {
        health -= i;
        int currentHealth = (int)health;
        healthBar.SetHealth(currentHealth);
    }
}
