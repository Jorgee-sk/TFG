using UnityEngine;

public class PlayerWander : NodeAction
{
    protected override void OnStart()
    {
        // throw new System.NotImplementedException();
    }

    protected override Status OnUpdate()
    {
        if (Vector2.Distance(context.gameObjectContext.transform.position,
                context.playerGameObjectCtx.transform.position) >
            context.enemyContext.DetectionRange)
        {
            return Status.Success;
        }

        return Status.Failure;
    }

    protected override void OnStop()
    {
        // throw new System.NotImplementedException();
    }
}