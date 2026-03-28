using _Project.Infrastructure.InGameTime;
using _Project.PlayerProgress;

namespace _Project.States
{
    public class FinishedLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgress _progress;
        private readonly IPersistentProgress _persistentProgress;
        private readonly IInGameTimeService _timeService;

        public FinishedLevelState(GameStateMachine gameStateMachine, IPersistentProgress progress,
            IPersistentProgress persistentProgress, IInGameTimeService timeService)
        {
            _gameStateMachine = gameStateMachine;
            _progress = progress;
            _persistentProgress = persistentProgress;
            _timeService = timeService;
        }

        public void Enter()
        {
            _timeService.EnablePause();
        }

        public void Exit() 
        {
            _timeService.RestoreTimePassage();
        }
    }
}