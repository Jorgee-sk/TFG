using UnityEngine;

public class HitPlayer : NodeAction
{
    protected override void OnStart()
    {
        // throw new System.NotImplementedException();
    }

    protected override Status OnUpdate()
    {
        if (Time.timeScale != 0f)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(context.gameObjectContext.transform.position,
                context.enemyContext.AttackRange, LayerMask.GetMask("Player"));

            if (colliders.Length > 0)
            {
                PlayerController.Health -= context.enemyContext.AttackDamage;
            }
        }

        return Status.Success;
    }

    protected override void OnStop()
    {
        // throw new System.NotImplementedException();
    }
}