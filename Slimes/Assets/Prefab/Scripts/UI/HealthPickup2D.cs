using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class inherits from the Pickup class and will heal the player when picked up
/// </summary>
public class HealthPickup2D : Pickup
{
    [Header("Healing Settings")]
    [Tooltip("The healing to apply")]
    public int healingAmount = 1;

    public override void DoOnPickup(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Health>() != null)
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth.currentHealth < playerHealth.maximumHealth)
            {
                playerHealth.ReceiveHealing(healingAmount);
                base.DoOnPickup(collision);
            }
        }
    }
}
