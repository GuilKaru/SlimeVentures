using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;
    public int damage = 40;

    public float waterBulletDestruction = 3f;
    public float fireBulletDestruction = 2f;
    public float earthBulletDestruction = 1f;

    [SerializeField]
    GameObject BulletType;
    //public float distance;
    //RaycastHit2D hitInfo;
    //public Rigidbody2D rb;
    IEnumerator DestroyWaterBulletAfterTime()
    {
        yield return new WaitForSeconds(waterBulletDestruction);
        Destroy(gameObject);
    }

    IEnumerator DestroyEarthBulletAfterTime()
    {
        yield return new WaitForSeconds(earthBulletDestruction);
        Destroy(gameObject);
    }

    IEnumerator DestroyFireBulletAfterTime()
    {
        yield return new WaitForSeconds(fireBulletDestruction);
        Destroy(gameObject);
    }
    private void Start()
    {
        Debug.Log(BulletType.name);
        if (BulletType.name == "Bullet(Clone)")
        {
            Debug.Log(BulletType.name);
            speed = 4f;
            damage = 20;
            StartCoroutine(DestroyWaterBulletAfterTime());
        }
        else if (BulletType.name == "EarthBullet(Clone)")
        {
            Debug.Log(BulletType.name);
            speed = 4f;
            damage = 50;
            StartCoroutine(DestroyEarthBulletAfterTime());
        }
        else if (BulletType.name == "FireBullet(Clone)")
        {
            Debug.Log(BulletType.name);
            speed = 5f;
            damage = 30;
            StartCoroutine(DestroyFireBulletAfterTime());
        }
    }

    

    /*private void OnEnable()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }*/

    /*private void Start()
    {
        rb.velocity = transform.right * speed;
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        *//*Debug.Log(collision.name);

        //Enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyHealth pupusito = collision.GetComponent<EnemyHealth>();

        pupusito.TakeDamage(damage);    *//*
        
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth pedritoGay = collision.GetComponent<EnemyHealth>();

            pedritoGay.TakeDamage(damage);
        }
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            EnemyHealth pedritoGay = collision.collider.GetComponent<EnemyHealth>();
            pedritoGay.TakeDamage(damage);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject);
        /* GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
         EnemyHealth enemy = Enemy.GetComponent<EnemyHealth>();*/

        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void Update()
    { 
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }*/
}
