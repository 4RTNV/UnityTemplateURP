namespace _Project.StateMachines
{
    public interface IAppState : IExitableAppState
    {
        void Enter();
    }
}
