using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats
{
    enum EnemyType
    {

    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }


    public override void ReceiveDamage(float damage)
    {
        currentHealth -= damage;
    }

    public override void RecieveHealing(int hpHealed)
    {
        currentHealth += hpHealed;
    }
}
