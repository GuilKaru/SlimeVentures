using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DeathEffectAnimationHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetIsDead();
    }

    // Update is called once per frame
    private void SetIsDead()
    {
        GetComponent<Animator>().SetTrigger("isDeadWater");
    }
}
