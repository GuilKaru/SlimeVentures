using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class which tracks when the Playert has achieved their objective
/// </summary>
public static class GoalManager
{
    //Boolean which tracks if the objective has been completed
    public static bool goalAchieved = false;
    
    /// <summary>
    /// Description:
    /// Marks the goal as achieved
    /// </summary>
    public static void CompleteGoal()
    {
        goalAchieved = true;
        if (GameManager.instance != null)
        {
            GameManager.instance.LevelCleared();
        }
    }

    /// <summary>
    /// Description:
    /// Resets goal completion (meant to be done on player death)
    /// </summary>
    public static void ResetGoal()
    {
        goalAchieved = false;
    }
}
