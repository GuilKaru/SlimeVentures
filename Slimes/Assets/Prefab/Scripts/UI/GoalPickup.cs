using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for pickups which end the level
/// </summary>
public class GoalPickup : Pickup
{
    /// <summary>
    /// Description:
    /// Function called when this pickup is picked up
    /// Tells the game manager that the level was cleared
    /// Input: 
    /// Collider2D collision
    /// Return: 
    /// void (no return)
    /// </summary>
    /// <param name="collision">The collider that is picking up this pickup</param>
    public override void DoOnPickup(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Health>() != null)
        {
            /*Debug.Log("Did the player collide?");*/
            //if (GameManager.instance != null)
            //{
                Debug.Log("Did i Finished the Game?");
                GameManager.instance.LevelCleared();
            //}
        }
        base.DoOnPickup(collision);
    }
}