using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Stats
{
    public Text PlayerHealth;
    void Update()
    {
        if (currentHealth <= 0)
        {
            //Destroy(this.gameObject);
        }
        PlayerHealth.text = "Health " + ":" + currentHealth;
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
