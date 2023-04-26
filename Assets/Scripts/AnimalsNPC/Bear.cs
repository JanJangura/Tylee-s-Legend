using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Nightmare
{
    public GameObject meat;
    public int damage = 1;
    public override void animationPlayDeath()
    {
        Destroy(this.gameObject);
        Instantiate(meat, this.transform.position, Quaternion.identity);
        Debug.Log("DEATH");
    }

    public override void animationDamageTaken()
    {
        Debug.Log("Hit");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            base.TakeDamage(damage);           
        }
    }
}
