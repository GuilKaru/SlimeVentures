using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyStateShooter : MonoBehaviour
{
    public AIPath aiPath;

    public SpriteRenderer spriteRenderer = null;
    
    private enum State
    {
        Patroling,
        AttackTarget
    }
    public Transform ThePlayer;

    public float targetRange = 30f;
    public float targetFarAway = 60f;
    private bool targetIsNear = false;

    private State state;


    private void Awake()
    {
        state = State.Patroling;
    }
    private void Update()
    {
        transform.localScale = new Vector3(4f, 4f, 1f);

        switch (state)
        {
            default:
            case State.Patroling:
                if (GetComponent<Pathfinding.Patrol>().enabled == false)
                {
                    GetComponent<Pathfinding.Patrol>().enabled = true;
                }
                FindTarget();
                break;
            case State.AttackTarget:
                GetComponent<Pathfinding.Patrol>().enabled = false;
                aiPath.maxSpeed = 0;
                TargetFarAway();
                break;
        }

        if (targetIsNear)
        {

            if (transform.position.x > ThePlayer.transform.position.x)
            {
                Debug.LogWarning("ME VORTIE IZQUIERDA");
                GetComponent<FieldOfView>().anglesin = -1.5708f;
                GetComponent<FieldOfView>().anglecos = -1.5708f;
                spriteRenderer.flipX = false;
                //transform.localScale = new Vector3(-1f, 1f, 1f);
                GetComponent<FieldOfView>().amIRight = false;
            }
            else if (transform.position.x < ThePlayer.transform.position.x)
            {
                Debug.LogWarning("ME VORTIE DERECHA");
                GetComponent<FieldOfView>().anglesin = 1.5708f;
                GetComponent<FieldOfView>().anglecos = 1.5708f;
                spriteRenderer.flipX = true;
                //transform.localScale = new Vector3(1f, 1f, 1f);
                GetComponent<FieldOfView>().amIRight = true;
            }
            
        } else
        {
            if (aiPath.desiredVelocity.x >= 0.01f || targetIsNear)
            {
                GetComponent<FieldOfView>().anglesin = 1.5708f;
                GetComponent<FieldOfView>().anglecos = 1.5708f;
                GetComponent<FieldOfView>().amIRight = true;
                spriteRenderer.flipX = true;
                //transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                GetComponent<FieldOfView>().anglesin = -1.5708f;
                GetComponent<FieldOfView>().anglecos = -1.5708f;
                GetComponent<FieldOfView>().amIRight = false;
                spriteRenderer.flipX = false;
                //transform.localScale = new Vector3(-1f, 1f, 1f);

            }
        }

        
    }

    private void FindTarget()
    {

        if (Vector2.Distance(transform.position, ThePlayer.transform.position) < targetRange)
        {
            targetIsNear = true;
            state = State.AttackTarget;
            //player within target range
        }
    }

    private void TargetFarAway()
    {

        if (Vector2.Distance(transform.position, ThePlayer.transform.position) > targetFarAway)
        {
            targetIsNear = false;
            aiPath.maxSpeed = 3;
            state = State.Patroling;
        }
        
    }
}
