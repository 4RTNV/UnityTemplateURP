using _Project.PersistentProgress;
using _Project.SaveLoad;

namespace _Project.StateMachines
{
    public class LoadProgressState : IAppState
    {
        private readonly AppStateMachine _appStateMachine;
        private readonly IPersistentProgress _persistentProgress;
        private readonly ISaveLoad _saveLoad;

        public LoadProgressState(AppStateMachine appStateMachine, IPersistentProgress persistentProgress,
            ISaveLoad saveLoad)
        {
            _appStateMachine = appStateMachine;
            _persistentProgress = persistentProgress;
            _saveLoad = saveLoad;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _appStateMachine.Enter<LoadMainMenuState>();
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _persistentProgress.Progress = _saveLoad.LoadProgress() ?? NewProgress();
        }

        private CurrentPlayerProgress NewProgress()
        {
            return new CurrentPlayerProgress();
        }
    }
}
