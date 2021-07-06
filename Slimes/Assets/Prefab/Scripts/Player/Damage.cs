using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the dealing of damage to health components.
/// </summary>
public class Damage : MonoBehaviour
{
    public LayerMask enemyLayer;
    [Header("Team Settings")]
    [Tooltip("The team associated with this damage")]
    public int teamId = 0;

    public GameObject Bullet;

    [Header("Damage Settings")]
    [Tooltip("How much damage to deal")]
    public int damageAmount = 40;
    [Tooltip("Whether or not to destroy the attached game object after dealing damage")]
    public bool destroyAfterDamage = true;
/*    [Tooltip("Whether or not to apply damage when triggers collide")]
    public bool dealDamageOnTriggerEnter = false;
    [Tooltip("Whether or not to apply damage when triggers stay, for damage over time")]
    public bool dealDamageOnTriggerStay = false;
    [Tooltip("Whether or not to apply damage on non-trigger collider collisions")]
    public bool dealDamageOnCollision = false;*/

    public float atkRange = 0.5f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyHealth enemy = collider.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        
    }

/*    private void OnTriggerStay2D(Collider2D collider)
    {
        if (dealDamageOnTriggerStay)
        {
            DealDamage(collider.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dealDamageOnCollision)
        {
            DealDamage(collision.gameObject);
        }
    }*/

   /* private void Update()
    {
        DamageEnemyAndDestroy();
    }

    private void DamageEnemyAndDestroy()
    {

    }*/

    /*private void DealDamage(GameObject collisionGameObject)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Bullet.transform.position, atkRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }

        *//*Health collidedHealth = collisionGameObject.GetComponent<Health>();
        if (collidedHealth != null)
        {
            if (collidedHealth.teamId != this.teamId)
            {
                collidedHealth.TakeDamage(damageAmount);
                if (destroyAfterDamage)
                {
                    Destroy(this.gameObject);
                }
            }
        }*/
        /*if (collidedHealth == null && collision.GetComponent<Rigidbody>() != null)
        {
            Debug.Log("Auch");
            collidedHealth = collision.GetComponent<Rigidbody>().GetComponent<Health>();
        }
        if (collidedHealth != null)
        {
            Debug.Log("Auch2");
            if (collidedHealth.teamId != this.teamId)
            {
                Debug.Log("Auch3");
                collidedHealth.TakeDamage(damageAmount);
                if (destroyAfterDamage)
                {
                    Debug.Log("Auch me dead");
                    Destroy(gameObject);
                }
            }
        }*//*
    }

    private void OnDrawGizmos()
    {
        if (Bullet == null)
            return;

        Gizmos.DrawWireSphere(Bullet.transform.position, atkRange);
        
    }*/
}
