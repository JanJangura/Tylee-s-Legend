using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    PlayerHealth player;
    public float damageSet = 25f;
    public float minDamage;
    public float maxDamage;

    public bool randomDamage;
    public bool setDamage;

   // public AudioClip[] sounds;
    //private AudioSource source;


    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

       // source = player.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        int ranDmg = (int)Random.Range(minDamage, maxDamage);

        if (other.gameObject.tag == "Player" && randomDamage)
        {
            player.damageTaken(ranDmg);
          //  source.clip = sounds[Random.Range(0, sounds.Length)];
           // source.Play();
        }

        if (other.gameObject.tag == "Player" && setDamage)
        {
            player.damageTaken((int)damageSet);
            Debug.Log(damageSet);
          //  source.clip = sounds[Random.Range(0, sounds.Length)];
           // source.Play();
        }
    }


    void Update()
    {

    }
}


