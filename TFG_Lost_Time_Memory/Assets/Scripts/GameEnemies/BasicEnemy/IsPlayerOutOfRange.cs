using UnityEngine;

public class IsPlayerOutOfRange : NodeAction
{
    protected override void OnStart()
    {
        //throw new System.NotImplementedException();
    }

    protected override Status OnUpdate()
    {
        return IsPlayerInDistance() ? Status.Failure : Status.Success;
    }

    protected override void OnStop()
    {
        //throw new System.NotImplementedException();
    }

    private bool IsPlayerInDistance()
    {
        return Vector2.Distance(context.gameObjectContext.transform.position,
            context.playerGameObjectCtx.transform.position) <= context.enemyContext.DetectionRange;
    }
}