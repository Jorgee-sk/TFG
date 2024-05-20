public class NodeRepeat : NodeDecorator
{
    public bool restartOnSuccess = true;
    public bool restartOnFailure;
    
    protected override void OnStart()
    {
      
    }

    protected override Status OnUpdate()
    {
        switch (child.Update())
        {
            case Status.Running:
                break;
            case Status.Failure:
                return restartOnFailure ? Status.Running : Status.Failure;
            case Status.Success:
                return restartOnSuccess ? Status.Running : Status.Failure;
        }

        return Status.Running;
    }

    protected override void OnStop()
    {
       
    }
}
