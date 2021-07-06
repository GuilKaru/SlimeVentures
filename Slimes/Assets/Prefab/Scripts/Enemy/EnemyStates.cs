using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyStates : MonoBehaviour
{
    public AIPath aiPath;

    public int dmgExplotion = 2;

    public SpriteRenderer spriteRenderer = null;

    /*private void Start()
    {
        sin = GetComponent<FieldOfView>().anglecos;
        cos = GetComponent<FieldOfView>().anglecos;
    }*/
    private enum State
    {
        Patroling,
        ChaseTarget
        //GoToStart
    }
    public Transform ThePlayer;
    //public GameObject EnemyState;
    //public Transform Enemy;
    public Transform StartPosition;

    public float targetRange = 50f;
    public float targetFarAway = 60f;
    /*private float blowDelay;
    private Vector2 blowDirection;
    private int force;*/
    //private bool explode = false;

    private State state;
    

    private void Awake()
    {
        state = State.Patroling;
    }
    private void Update()
    {
        transform.localScale = new Vector3(4f, 4f, 1f);

        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            spriteRenderer.flipX = true;
            //transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            spriteRenderer.flipX = false;
            //transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        switch (state)
        {
            default:
            case State.Patroling:
                if (GetComponent<Pathfinding.Patrol>().enabled == false)
                {
                    GetComponent<Pathfinding.Patrol>().enabled = true;
                    GetComponent<Pathfinding.AIDestinationSetter>().enabled = false;
                    GetComponent<Pathfinding.PatrolToStart>().enabled = false;
                }
                FindTarget();
                break;
            case State.ChaseTarget:
                if (GetComponent<Pathfinding.AIDestinationSetter>().enabled == false)
                {
                    GetComponent<Pathfinding.AIDestinationSetter>().enabled = true;
                    GetComponent<Pathfinding.PatrolToStart>().enabled = false;
                    GetComponent<Pathfinding.Patrol>().enabled = false;
                }
                TargetFarAway();
                break;
            /*case State.GoToStart:
                if (GetComponent<Pathfinding.PatrolToStart>().enabled == false)
                {
                    GetComponent<Pathfinding.PatrolToStart>().enabled = true;
                    GetComponent<Pathfinding.AIDestinationSetter>().enabled = false;
                    GetComponent<Pathfinding.Patrol>().enabled = false;
                }
                FindTarget();
                if(transform.position == StartPosition.position)
                {
                    state = State.Patroling;
                }
                break;*/
        }
        /*if (blowDelay < Time.time)
            explode = false;

        if (explode)
        {
            ThePlayer.GetComponent<Rigidbody2D>().AddForce(blowDirection * force, ForceMode2D.Impulse);
            Destroy(gameObject);
        }*/
        
        
        //ThePlayer.transform.position = ThePlayer.transform.position;
    }

    private void FindTarget()
    {
        
        if (Vector2.Distance(transform.position, ThePlayer.transform.position) < targetRange)
        {
            state = State.ChaseTarget;
            //player within target range
        }
    }

    private void TargetFarAway()
    {
        
        if (Vector2.Distance(transform.position, ThePlayer.transform.position) > targetFarAway)
        {
            state = State.Patroling;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            /*blowDelay = Time.time + 0.3f;
            explode = true;
            force = 5000;
            Vector2 dir = collision.contacts[0].point - ThePlayer.GetComponent<Rigidbody2D>().position;
            blowDirection = -dir.normalized;*/

            Health playerHealth = ThePlayer.GetComponent<Health>();
            playerHealth.TakeDamage(dmgExplotion);
            Destroy(gameObject);
        }
    }
}


