public interface IState
{
    public void OnEnterState();
    public void OnExitState();
    public void Execute();
    public void FixedExecute();
}
