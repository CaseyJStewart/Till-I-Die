using UnityEngine;
using System.Collections;

public abstract class Stats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    [Tooltip("The max health the character can possibly have")]
    protected float maxHealth;
    [SerializeField]
    [Tooltip("The character's current health")]
    protected float currentHealth;
    
    public abstract void ReceiveDamage(float damage);
    public abstract void RecieveHealing(int hpHealed);
}