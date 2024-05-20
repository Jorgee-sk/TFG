using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerInRange : NodeAction
{
    protected override void OnStart()
    {
        // throw new System.NotImplementedException();
    }

    protected override void OnStop()
    {
        // throw new System.NotImplementedException();
    }

    protected override Status OnUpdate()
    {
        return IsPlayerInDistance() ? Status.Success : Status.Failure;
    }

    private bool IsPlayerInDistance()
    {
        return Vector2.Distance(context.gameObjectContext.transform.position,
            context.playerGameObjectCtx.transform.position) <= context.enemyContext.DetectionRange;
    }
}