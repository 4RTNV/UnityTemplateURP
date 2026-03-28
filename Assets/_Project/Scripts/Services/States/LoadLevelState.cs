using _Project.Factory;
using _Project.CurrentLevelProgress;
using _Project;
using _Project.PlayerProgress;
using _Project.StaticData;
using _Project.UI.Services;
using _Project.UI.Services.Factory;
using UnityEngine;

namespace _Project.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IPersistentProgress _progress;
        private readonly IUIFactory _uiFactory;
        private readonly GameStateMachine _gameStateMachine;
        private readonly IStaticData _staticData;
        private readonly IGameFactory _gameFactory;
        private readonly Canvas _loadingCurtain;
        private readonly ILevelProgress _levelProgress;

        public LoadLevelState(GameStateMachine gameStateMachine,
            IGameFactory gameFactory, IPersistentProgress progress,
            IStaticData staticData, IUIFactory uiFactory,
            ILevelProgress levelProgress)
        {
            _gameStateMachine = gameStateMachine;
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
            => _loadingCurtain.gameObject.SetActive(false);

        private void OnLoaded()
        {
            LevelConfig config = _staticData.ForLevel(_progress.Progress.CurrentLevel);
            _levelProgress.LoadLevelConfig(config);
            InitializeInGameHUD();
            InitializeCamera();
            _gameStateMachine.Enter<LoopLevelState>();
        }

        private void InitializeCamera()
        {
            GameObject cameraSpawnPoint = GameObject.FindGameObjectWithTag(Constants.CameraSpawnPoint);
        }

        private void InitializeInGameHUD()
        {
            _uiFactory.CreateUIRoot();

        }
    }
}