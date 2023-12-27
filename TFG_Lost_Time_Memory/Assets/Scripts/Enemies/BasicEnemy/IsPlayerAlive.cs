using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsPlayerAlive : NodeAction
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
        if (!CheckPlayerAlive())
        {
            Destroy(context.playerGameObjectCtx);
            Destroy(context.gameObjectContext);
        }

        return CheckPlayerAlive() ? Status.Success : Status.Failure;
    }

    private bool CheckPlayerAlive()
    {
        return PlayerController.Health > 0;
    }
}