using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject startingWeapon;
    [SerializeField] private Transform gunHolderTr;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private NavMeshAgent agent;
    private Transform currentTarget;
    private Weapon currentWeapon;
    void Awake()
    {
        currentWeapon = Instantiate(startingWeapon, gunHolderTr.position, gunHolderTr.rotation).GetComponent<Weapon>();
        currentWeapon.transform.SetParent(gunHolderTr);
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component missing on this GameObject.");
            enabled = false;
            return;
        }

        if (pointA == null || pointB == null)
        {
            Debug.LogError("Point A or Point B not assigned in inspector.");
            enabled = false;
            return;
        }

        currentTarget = pointA;
        agent.SetDestination(currentTarget.position);
    }
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
            agent.SetDestination(currentTarget.position);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            int enemyLayerBit = 1 << gameObject.layer;

            if ((bullet.TargetLayer.value & enemyLayerBit) != 0)
            {
                Debug.Log("Enemy damaged");
            }
        }
    }
}
