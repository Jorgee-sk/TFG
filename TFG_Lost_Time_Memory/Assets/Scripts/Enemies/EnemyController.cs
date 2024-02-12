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
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationModifier;
    
    private Quaternion _lookRotation;
    private Vector3 _direction;
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
        target = GameObject.FindGameObjectWithTag("Player").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        _direction = (target.transform.position - transform.position);
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
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