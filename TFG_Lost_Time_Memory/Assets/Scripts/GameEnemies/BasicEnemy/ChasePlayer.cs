using UnityEngine;

public class ChasePlayer : NodeAction
{
    protected override void OnStart()
    {
        // throw new System.NotImplementedException();
    }

    protected override Status OnUpdate()
    {
        return EnemyChasePlayer() ? Status.Success : Status.Running;
    }

    protected override void OnStop()
    {
        // throw new System.NotImplementedException();
    }

    private bool EnemyChasePlayer()
    {
        GameObject enemy = context.enemyContext.gameObject;
        Animator animator = enemy.GetComponent<Animator>();
        
        
        context.agent.SetDestination(context.playerGameObjectCtx.transform.position);
        float distance = Vector2.Distance(context.gameObjectContext.transform.position, context.agent.destination);

        if (context.enemyContext.AnimatedSprite && animator != null)
        {
            if (distance != 0)
            {
                float x = context.agent.destination.x - context.gameObjectContext.transform.position.x;
                float y = context.agent.destination.y - context.gameObjectContext.transform.position.y;

                animator.SetFloat("MoveX", x);
                animator.SetFloat("MoveY", y);
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }
        
        return distance <= context.enemyContext.DetectionRange;
    }
}