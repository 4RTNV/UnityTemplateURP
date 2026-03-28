using System.Collections.Generic;
using _Project.Services.PlayerProgress;

namespace _Project.Services.States
{
    public class HubState : IState
    {
        public IEnumerable<ISavedProgressReader> SaveReaderServices { get; }
        
        private readonly IEnumerator<ISavedProgressReader> _saveReaderServices;
        private readonly GameStateMachine _gameStateMachine;

        public HubState(GameStateMachine gameStateMachine, IEnumerable<ISavedProgressReader> saveReaderServices)
        {
            _gameStateMachine = gameStateMachine;
            SaveReaderServices = saveReaderServices;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}