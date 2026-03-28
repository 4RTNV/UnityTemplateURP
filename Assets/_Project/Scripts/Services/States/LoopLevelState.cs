using _Project.Infrastructure.InGameTime;
using _Project.Infrastructure.SaveLoad;
using _Project.CurrentLevelProgress;
using _Project.PlayerProgress;

namespace _Project.States
{
    public class LoopLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISaveLoad _saveLoad;
        private readonly IPersistentProgress _progress;
        private readonly IInGameTimeService _timeService;
        private readonly ILevelProgress _levelProgress;
        private bool _isWaveOngoing;

        public LoopLevelState(GameStateMachine gameStateMachine, ISaveLoad saveLoad, ILevelProgress levelProgress)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoad = saveLoad;
            _levelProgress = levelProgress;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            _timeService.RestoreTimePassage();
        }
    }
}