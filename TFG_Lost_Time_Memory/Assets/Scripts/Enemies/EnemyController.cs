using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int detectionRange;
    [SerializeField] private int attackRange;
    [SerializeField] private int attackDamage;
    private NavMeshAgent _navMeshAgent;

    public static EnemyController Instance { get; private set; }

    public int AttackDamage
    {
        get => attackDamage;
        set => attackDamage = value;
    }

    public int AttackRange
    {
        get => attackRange;
        set => attackRange = value;
    }
    
    public int DetectionRange
    {
        get => detectionRange;
        set => detectionRange = value;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            Death();
        }
    }


    private void Death()
    {
        Destroy(gameObject);
    }
}