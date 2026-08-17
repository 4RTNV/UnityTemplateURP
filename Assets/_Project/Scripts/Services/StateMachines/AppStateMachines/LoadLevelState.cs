using _Project.CurrentLevelProgress;
using _Project.Factory;
using _Project.PersistentProgress;
using _Project.StaticData;
using _Project.UI.Factory;
using UnityEngine;

namespace _Project.StateMachines
{
    public class LoadLevelState : IPayloadedAppState<string>
    {
        private readonly AppStateMachine _appStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly ILevelProgress _levelProgress;
        private readonly Canvas _loadingCurtain;
        private readonly IPersistentProgress _progress;
        private readonly IStaticData _staticData;
        private readonly IUIFactory _uiFactory;

        public LoadLevelState(AppStateMachine appStateMachine, IGameFactory gameFactory, IPersistentProgress progress,
            IStaticData staticData, IUIFactory uiFactory, ILevelProgress levelProgress)
        {
            _appStateMachine = appStateMachine;
            _gameFactory = gameFactory;
            _progress = progress;
            _staticData = staticData;
            _uiFactory = uiFactory;
            _levelProgress = levelProgress;
        }

        public void Enter(string sceneName)
        {
            _gameFactory.CleanUp();
            _loadingCurtain.gameObject.SetActive(true);
        }

        public void Exit()
        {
            _loadingCurtain.gameObject.SetActive(false);
        }
    }
}
