using _Project.Data;
using _Project.Infrastructure.SaveLoad;
using _Project.PlayerProgress;

namespace _Project.States
{
    public class LoadProgressState : IState
    {
        private readonly IPersistentProgress _persistentProgress;
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISaveLoad _saveLoad;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgress persistentProgress,
            ISaveLoad saveLoad)
        {
            _gameStateMachine = gameStateMachine;
            _persistentProgress = persistentProgress;
            _saveLoad = saveLoad;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadHubState>();
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _persistentProgress.Progress = _saveLoad.LoadProgress() ?? NewProgress();
        }

        private CurrentPlayerProgress NewProgress() 
            => new();
    }
}