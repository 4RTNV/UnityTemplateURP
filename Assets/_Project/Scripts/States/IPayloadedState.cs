namespace _Project.States
{
    public interface IPayloadedState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payload);
    }
}
