using System.Collections.Generic;

namespace _Project.StateMachines
{
    public interface IAppStateFactory
    {
        IEnumerable<IExitableAppState> CreateStates(AppStateMachine appStateMachine);
    }
}
