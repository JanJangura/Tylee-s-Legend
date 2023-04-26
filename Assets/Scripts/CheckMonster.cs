using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMonster : EnemyDamage
{
    public override void checkBool()
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
}
