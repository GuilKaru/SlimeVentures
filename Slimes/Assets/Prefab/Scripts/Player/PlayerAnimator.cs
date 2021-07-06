using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The player controller script to read state information from")]
    public SlimeMovement playerController;
    [Tooltip("The animator component that controls the player's animations")]
    public Animator animator;
    private bool iWasWater = true;
    private bool iWasFire = false;
    private bool iWasEarth = false;

    //Player Shooting Script
    public TDPlayerController playerElement;

    private void Start()
    {
        ReadPlayerStateAndAnimate();
    }

    private void Update()
    {
        ReadPlayerStateAndAnimate();
    }

    void ReadPlayerStateAndAnimate()
    {
        if (animator == null)
        {
            return;
        }
        if (playerElement.state == TDPlayerController.State.Water)
        {
            if(iWasEarth == true)
            {
                animator.ResetTrigger("TransWaterEarth");
                animator.ResetTrigger("TransFireEarth");
                animator.SetTrigger("TransEarthWater");
            }
            if (iWasFire == true)
            {
                animator.ResetTrigger("TransWaterFire");
                animator.ResetTrigger("TransEarthFire");
                animator.SetTrigger("TransFireWater");
            }
            /*if (playerElement.isWater == true)
            {
                animator.SetBool("isShootingWater", true);
                animator.SetBool("isShootingFire", false);
                animator.SetBool("isShootingEarth", false);
            } else
            {
                animator.SetBool("isShootingWater", false);
            }*/
            if (playerController.state == SlimeMovement.PlayerState.Idle)
            {
                animator.SetBool("isIdleWater", true);
                animator.SetBool("isIdleEarth", false);
                animator.SetBool("isIdleFire", false);

            }
            else
            {
                animator.SetBool("isIdleWater", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Jump)
            {
                animator.SetBool("isJumpingWater", true);
                animator.SetBool("isJumpingEarth", false);
                animator.SetBool("isJumpingFire", false);
            }
            else
            {
                animator.SetBool("isJumpingWater", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Fall)
            {
                animator.SetBool("isFallingWater", true);
                animator.SetBool("isFallingEarth", false);
                animator.SetBool("isFallingFire", false);
            }
            else
            {
                animator.SetBool("isFallingWater", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Walk)
            {
                animator.SetBool("isWalkingWater", true);
                animator.SetBool("isWalkingEarth", false);
                animator.SetBool("isWalkingFire", false);
            }
            else
            {
                animator.SetBool("isWalkingWater", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Dead)
            {
                animator.SetBool("isDeadWater", true);
                animator.SetBool("isDeadEarth", false);
                animator.SetBool("isDeadFire", false);
            }
            else
            {
                animator.SetBool("isDeadWater", false);
            }
            iWasWater = true;
            iWasEarth = false;
            iWasFire = false;
        }
        else if (playerElement.state == TDPlayerController.State.Earth)
        {
            if (iWasWater == true)
            {
                animator.ResetTrigger("TransEarthWater");
                animator.ResetTrigger("TransFireWater");
                animator.SetTrigger("TransWaterEarth");
            }
            if (iWasFire == true)
            {
                animator.ResetTrigger("TransWaterFire");
                animator.ResetTrigger("TransEarthFire");
                animator.SetTrigger("TransFireEarth");
            }
           /* if (playerElement.isEarth == true)
            {
                animator.SetBool("isShootingEarth", true);
                animator.SetBool("isShootingWater", false);
                animator.SetBool("isShootingFire", false);
            }
            else
            {
                animator.SetBool("isShootingEarth", false);
            }*/

            if (playerController.state == SlimeMovement.PlayerState.Idle)
            {
                animator.SetBool("isIdleEarth", true);
                animator.SetBool("isIdleWater", false);
                animator.SetBool("isIdleFire", false);
            }
            else
            {
                animator.SetBool("isIdleEarth", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Jump)
            {
                animator.SetBool("isJumpingEarth", true);
                animator.SetBool("isJumpingWater", false);
                animator.SetBool("isJumpingFire", false);
            }
            else
            {
                animator.SetBool("isJumpingEarth", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Fall)
            {
                animator.SetBool("isFallingEarth", true);
                animator.SetBool("isFallingWater", false);
                animator.SetBool("isFallingFire", false);
            }
            else
            {
                animator.SetBool("isFallingEarth", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Walk)
            {
                animator.SetBool("isWalkingEarth", true);
                animator.SetBool("isWalkingWater", false);
                animator.SetBool("isWalkingFire", false);
            }
            else
            {
                animator.SetBool("isWalkingEarth", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Dead)
            {
                animator.SetBool("isDeadEarth", true);
                animator.SetBool("isDeadWater", false);
                animator.SetBool("isDeadFire", false);
            }
            else
            {
                animator.SetBool("isDeadEarth", false);
            }
            
            iWasWater = false;
            iWasEarth = true;
            iWasFire = false;
        }
        else if (playerElement.state == TDPlayerController.State.Fire)
        {
            if (iWasWater == true)
            {
                animator.ResetTrigger("TransEarthWater");
                animator.ResetTrigger("TransFireWater");
                animator.SetTrigger("TransWaterFire");
            }
            if (iWasEarth == true)
            {
                animator.ResetTrigger("TransWaterEarth");
                animator.ResetTrigger("TransFireEarth");
                animator.SetTrigger("TransEarthFire");
            }
            /*if (playerElement.isFire == true)
            {
                animator.SetBool("isShootingFire", true);
                animator.SetBool("isShootingWater", false);
                animator.SetBool("isShootingEarth", false);
            }
            else
            {
                animator.SetBool("isShootingFire", false);
            }*/

            if (playerController.state == SlimeMovement.PlayerState.Idle)
            {
                animator.SetBool("isIdleFire", true);
                animator.SetBool("isIdleWater", false);
                animator.SetBool("isIdleEarth", false);
            }
            else
            {
                animator.SetBool("isIdleFire", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Jump)
            {
                animator.SetBool("isJumpingFire", true);
                animator.SetBool("isJumpingWater", false);
                animator.SetBool("isJumpingEarth", false);
            }
            else
            {
                animator.SetBool("isJumpingFire", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Fall)
            {
                animator.SetBool("isFallingFire", true);
                animator.SetBool("isFallingWater", false);
                animator.SetBool("isFallingEarth", false);
            }
            else
            {
                animator.SetBool("isFallingFire", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Walk)
            {
                animator.SetBool("isWalkingFire", true);
                animator.SetBool("isWalkingWater", false);
                animator.SetBool("isWalkingEarth", false);
            }
            else
            {
                animator.SetBool("isWalkingFire", false);
            }

            if (playerController.state == SlimeMovement.PlayerState.Dead)
            {
                animator.SetBool("isDeadFire", true);
                animator.SetBool("isDeadWater", false);
                animator.SetBool("isDeadEarth", false);
            }
            else
            {
                animator.SetBool("isDeadFire", false);
            }
            iWasWater = false;
            iWasEarth = false;
            iWasFire = true;
        }

    }
}
