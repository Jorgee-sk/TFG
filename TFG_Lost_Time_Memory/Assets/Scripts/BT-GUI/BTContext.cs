using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTContext : MonoBehaviour
{
    public GameObject gameObjectContext;
    public GameObject playerGameObjectCtx;
    public Rigidbody physics;
    public NavMeshAgent agent;
    //TODO Jorge revisar los collider 2D, quizas sea mejor usar Polygon collider
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;
    public CharacterController characterController;
    public Rigidbody2D rigidBodyContext;
    public PlayerController playerContext;
    public EnemyController enemyContext;

    public static BTContext CreateFromGameObjectToTarget(GameObject gameObject, GameObject playerGameObject,
        PlayerController targetPlayer, EnemyController targetEnemy)
    {
        BTContext context = new BTContext();
        context.gameObjectContext = gameObject;
        context.playerGameObjectCtx = playerGameObject;
        context.physics = gameObject.GetComponent<Rigidbody>();
        context.agent = gameObject.GetComponent<NavMeshAgent>();
        context.agent.updateRotation = false;
        context.agent.updateUpAxis = false;
        context.boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        context.circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        context.characterController = gameObject.GetComponent<CharacterController>();
        context.playerContext = targetPlayer;
        context.enemyContext = targetEnemy;

        if (gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            context.rigidBodyContext = rb;
        }
        
        
        return context;
    }
}
