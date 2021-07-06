using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public float anglesin = 0f;
    public float anglecos = 0f;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public bool amIRight = true;
    public AIPath aiPath;

    public float attackRate = 0.5f;

    private bool canShoot = true;

    public GameObject Bullet;
    public Transform shootPos;
    public Transform Player;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    private void Start()
    {
        //aiPath = Enemy.GetComponent<AIPath>();
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();

        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if(amIRight)
            {
                if (Vector3.Angle(transform.right, dirToTarget) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                    {
                        EnemyShoot();
                        visibleTargets.Add(target);
                    }
                }
            } else if (!amIRight)
            {
                if (Vector3.Angle(-transform.right, dirToTarget) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                    {
                        EnemyShoot();
                        visibleTargets.Add(target);
                    }
                }
            }
            
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad + anglesin), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad + anglecos), 0);
    }

    private void EnemyShoot()
    {
        if (!canShoot) return;

        GameObject enemyBullet = Instantiate(Bullet, shootPos.position, Quaternion.identity);
        StartCoroutine(ICanShoot());

    }

    IEnumerator ICanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(attackRate);
        canShoot = true;
    }
}
