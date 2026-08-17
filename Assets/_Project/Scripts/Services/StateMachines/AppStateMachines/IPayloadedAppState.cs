namespace _Project.StateMachines
{
    public interface IPayloadedAppState<TPayload> : IExitableAppState
    {
        void Enter(TPayload payload);
    }
}
