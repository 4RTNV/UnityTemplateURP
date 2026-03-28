using _Project.TimeService;

namespace _Project.States
{
    public class FinishedLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IInGameTimeService _timeService;

        public FinishedLevelState(GameStateMachine gameStateMachine, IInGameTimeService timeService)
        {
            _gameStateMachine = gameStateMachine;
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