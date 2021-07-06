using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TheBulletTeleport;

    private PlayerInputs controls;
    private bool didItTeleport = false;

    private void Awake()
    {
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

    public bool areYouTeleporting()
    {
        if (didItTeleport)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void TeleportToTarget(Transform Bullet)
    {
        ThePlayer.transform.position = Bullet.transform.position;
        didItTeleport = true;
    }
}
