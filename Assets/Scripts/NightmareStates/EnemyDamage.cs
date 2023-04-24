using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject player;
    private float damageRange;
    public float damageSet = 25f;
    public float minDamage;
    public float maxDamage;

    public bool randomDamage;
    public bool setDamage;

   // public AudioClip[] sounds;
    //private AudioSource source;


    void Start()
    {
        damageRange = Random.Range(minDamage, maxDamage);
       // source = player.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && randomDamage)
        {
            player.GetComponent<PlayerHealth>().health -= damageRange;
          //  source.clip = sounds[Random.Range(0, sounds.Length)];
           // source.Play();
        }

        if (other.gameObject.tag == "Player" && setDamage)
        {
            player.GetComponent<PlayerHealth>().health -= damageSet;
          //  source.clip = sounds[Random.Range(0, sounds.Length)];
           // source.Play();
        }

    }


    void Update()
    {

    }
}


