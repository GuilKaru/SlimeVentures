using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleBulletController : MonoBehaviour
{

    [SerializeField]
    private float speed = 4f;
    private PlayerInputs controls;
    public Transform TeleportingBullet;
    Vector3 tempVect;

    private Rigidbody2D rb;

   TeleportPlayer goToTeleport;

  /*  public Transform teleportTarget;
    public Transform thePlayer;*/
    //public InputManager inputManager = null;
    //Quaternion startRotation = Quaternion.Euler(Vector3.zero);
    private void Awake()
    {
        controls = new PlayerInputs();
        goToTeleport = GameObject.Find("Player").GetComponent<TeleportPlayer>();
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator DestroyTeleBulletAfterTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        controls.Enable();
        StartCoroutine(DestroyTeleBulletAfterTime());
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        //rb.AddRelativeForce(Vector3.right * speed, ForceMode2D.Impulse);
        rb.AddRelativeForce(Vector3.right * speed);
    }
    void Update()
    {
        //lastVelocity = rb.velocity;
        if (controls.Player.TeleportingButton.triggered)
        {
            fckingTeleport();
            Destroy(gameObject);
        }
        //else
        //{
            /*tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.right + tempVect);*/
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
            //rb.AddRelativeForce(Vector3.right * speed, ForceMode2D.Impulse);
        //}
    }

    private void fckingTeleport()
    {
        goToTeleport.TeleportToTarget(TeleportingBullet);
    }

    /*private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Obstacle")
        {
            float speedBull = lastVelocity.magnitude;
            Vector3 bullDir = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
            rb.velocity = bullDir * Mathf.Max(speedBull, 0f);
        }
        
    }*/

    /*public bool CheckTeleported()
    {
        if (controls.Player.TeleportingButton.triggered)
        {
            TeleportPlayer();
            return true;
        } else
        {
            return false;
        }
    }*/

   /* private void CheckTeleInput()
    {
        //Debug.LogWarning(thePlayer.transform.position);
        if (inputManager != null)
        {
            
            if (inputManager.teleButton == 1)
            {
                Debug.Log(inputManager.teleButton);
                TeleportPlayer();
                inputManager.teleButton = 0;
            }
        }
    }*/

    /*private void TeleportPlayer()
    {
        Debug.Log(controls.Player.TeleportingButton.triggered);
        //thePlayer.transform.position = teleportTarget.transform.position;
        thePlayer.transform.Translate(teleportTarget.transform.position);
        //thePlayer.transform.SetPositionAndRotation(teleportTarget.transform.position, startRotation);
        Destroy(gameObject);
    }*/

   /* private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }*/
}
