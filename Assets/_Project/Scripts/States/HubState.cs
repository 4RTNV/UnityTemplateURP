using System.Collections.Generic;
using _Project.PersistentProgress;

namespace _Project.States
{
    public class HubState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        private readonly IEnumerator<ISavedProgressReader> _saveReaderServices;

        public HubState(GameStateMachine gameStateMachine, IEnumerable<ISavedProgressReader> saveReaderServices)
        {
            _gameStateMachine = gameStateMachine;
            SaveReaderServices = saveReaderServices;
        }

        public IEnumerable<ISavedProgressReader> SaveReaderServices { get; }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}
