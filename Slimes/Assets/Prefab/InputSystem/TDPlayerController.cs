using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TDPlayerController : MonoBehaviour
{

    [SerializeField]
    private GameObject WaterBullet;
    [SerializeField]
    private GameObject FireBullet;
    [SerializeField]
    private GameObject EarthBullet;

    private GameObject StateBullet;

    public Animator animator;

    [HideInInspector]
    public bool isWater = false;
    [HideInInspector]
    public bool isFire = false;
    [HideInInspector]
    public bool isEarth = false;

    [SerializeField]
    private Transform bulletDirection;
    [SerializeField]
    private GameObject teleBullet;
    [SerializeField]
    private Transform teleBulletDirection;

    private PlayerInputs controls;
    private bool canShoot = true;
    private bool teleShoot = true;
    private Camera main;
    private GameObject bulletDir;

    public float canShootWater = 0.5f;
    public float canShootEarth = 1.5f;
    public float canShootFire = 0.2f;

    public enum State
    {
        Water,
        Fire,
        Earth
    }

    public State state;
    private void Awake()
    {
        state = State.Water;
        bulletDir = GameObject.Find("BulletDirection");
        controls = new PlayerInputs();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }


    void Start()
    {
        main = Camera.main;
        controls.Player.Shoot.performed += _ => PlayerShoot();
        controls.Player.TeleportingShoot.performed += _ => TeleportingShoot();
    }

    private void PlayerShoot()
    {
        if (!canShoot) return;

        if (isWater)
        {
            animator.SetBool("isShootingWater", true);
        }
        else if (isEarth)
        {
            animator.SetBool("isShootingEarth", true);
        }
        else if (isFire)
        {
            animator.SetBool("isShootingFire", true);
        }

        Vector2 mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();
        mousePosition = main.ScreenToViewportPoint(mousePosition);
        GameObject normalBullet = Instantiate(StateBullet, bulletDirection.position, bulletDirection.rotation);
        normalBullet.SetActive(true);

        animator.SetBool("isShootingWater", false);
        animator.SetBool("isShootingEarth", false);
        animator.SetBool("isShootingFire", false);

        if (isWater)
        {
            StartCoroutine(CanShootWater());
        }
        else if (isEarth)
        {
            StartCoroutine(CanShootEarth());
        }
        else if (isFire)
        {
            StartCoroutine(CanShootFire());
        }
    }

    IEnumerator CanShootWater()
    {
        canShoot = false;
        yield return new WaitForSeconds(canShootWater);
        canShoot = true;
        isWater = false;
    }
    IEnumerator CanShootEarth()
    {
        canShoot = false;
        yield return new WaitForSeconds(canShootEarth);
        canShoot = true;
        isEarth = false;
    }
    IEnumerator CanShootFire()
    {
        canShoot = false;
        yield return new WaitForSeconds(canShootFire);
        canShoot = true;
        isFire = false;
    }

    private void TeleportingShoot()
    {
        if (!teleShoot) return;
        
        Vector2 mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();
        mousePosition = main.ScreenToViewportPoint(mousePosition);
        GameObject telepBullet = Instantiate(teleBullet, teleBulletDirection.position, teleBulletDirection.rotation);
        telepBullet.SetActive(true);
        
        StartCoroutine(TeleShoot());
    }

    IEnumerator TeleShoot()
    {
        teleShoot = false;
        yield return new WaitForSeconds(5f);
        teleShoot = true;
    }

    
    void Update()
    {
        controls.Player.WeaponWater.performed += _ => SetState("Water");
        controls.Player.WeaponFire.performed += _ => SetState("Fire");
        controls.Player.WeaponEarth.performed += _ => SetState("Earth");

        switch (state)
        {
            default:
            case State.Water:
                StateBullet = WaterBullet;
                isWater = true;
                Debug.Log(isWater);
                
                break;
            case State.Fire:
                //Debug.Log("Fire");
                StateBullet = FireBullet;
                isFire = true;
                break;
            case State.Earth:
                //Debug.Log("Earth");
                StateBullet = EarthBullet;
                isEarth = true;
                break;
        }

        


        //READ MOUSE POSITION
        Vector3 mouseScreenPosition = controls.Player.MousePosition.ReadValue<Vector2>();
        mouseScreenPosition.z = 10;
        //Debug.Log(mouseScreenPosition);
        Vector3 mouseWorldPosition = main.ScreenToWorldPoint(mouseScreenPosition);
        //Debug.Log(mouseWorldPosition);
        Vector3 targetDirection = mouseWorldPosition - bulletDir.transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        bulletDir.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void SetState(string Element)
    {
        if (Element == "Water")
        {
            state = State.Water;
        }
        else if (Element == "Fire")
        {
            state = State.Fire;
        }
        else if (Element == "Earth")
        {
            state = State.Earth;
        }
    }
}
