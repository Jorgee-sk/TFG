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
        context.agent.SetDestination(context.playerGameObjectCtx.transform.position);
        float distance = Vector2.Distance(context.gameObjectContext.transform.position, context.agent.destination);
        return distance <= context.enemyContext.DetectionRange;
    }
}