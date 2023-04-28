using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth player;
    public PlayerMovement playerMovement;
    public float damageSet = 25f;
    public float minDamage;
    public float maxDamage;

    public bool randomDamage;
    public bool setDamage;
    public bool AnkleBiter;
    public bool NightMare;

   // public AudioClip[] sounds;
    //private AudioSource source;


    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        // source = player.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        int ranDmg = (int)Random.Range(minDamage, maxDamage);

        if (other.gameObject.tag == "Player" && randomDamage)
        {
            player.damageTaken(ranDmg);
            checkBool();
          //  source.clip = sounds[Random.Range(0, sounds.Length)];
          // source.Play();
        }

        if (other.gameObject.tag == "Player" && setDamage)
        {
            player.damageTaken((int)damageSet);
            checkBool();
            Debug.Log(damageSet);
          //  source.clip = sounds[Random.Range(0, sounds.Length)];
           // source.Play();
        }
    }

    public virtual void checkBool()
    {
        if (AnkleBiter)
        {
            playerMovement.isAnkleBiter = true;
        }
        else if (NightMare)
        {
            playerMovement.isNightMare = true;
        }
    }

    void Update()
    {

    }
}


