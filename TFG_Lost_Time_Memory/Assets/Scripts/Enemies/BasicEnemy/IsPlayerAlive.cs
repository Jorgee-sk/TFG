using UnityEngine;

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
        //TODO REVISAR lo de que cuando se muera el personaje nos saque un panel pausandonos el juego, lo que se podría
        // hacer es poner que se ejecute el código de abajo con tal entonces cuando abras el panel de que has perdido 
        // pues ya pones el time a 1f de nuevo
        if (!CheckPlayerAlive())
        {
            if (PlayerController.Score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", PlayerController.Score);
            }
            PlayerController.StopGame();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Destroy(context.playerGameObjectCtx);
            //Destroy(context.gameObjectContext);
        }
        
        return CheckPlayerAlive() ? Status.Success : Status.Failure;
    }

    private bool CheckPlayerAlive()
    {
        return PlayerController.Health > 0;
    }
}