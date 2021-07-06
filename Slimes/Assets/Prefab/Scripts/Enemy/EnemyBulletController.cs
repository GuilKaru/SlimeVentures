using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;
    public int damage = 40;
    public float atkSpeed = 3f;

    Rigidbody2D rb;
    public GameObject ThePlayer;

    Vector2 moveDirection;
    
    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(atkSpeed);
        Destroy(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ThePlayer = GameObject.FindGameObjectWithTag("Player");
        if (ThePlayer != null)
        {
            moveDirection = (ThePlayer.transform.position - transform.position).normalized * speed;
        }
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
    private void OnEnable()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    /*void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }*/
}
