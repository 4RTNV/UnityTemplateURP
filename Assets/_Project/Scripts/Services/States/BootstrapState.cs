using _Project.Infrastructure;
using _Project.AssetManagement;
using _Project.SceneLoader;

namespace _Project.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            SingletonCoroutineRunner.Instance.StartCoroutine(
                _sceneLoader.LoadScene(SceneNames.BootstrapSceneName, onLoaded: EnterHub));
        }

        public void Exit() {}

        private void EnterHub()
            => _gameStateMachine.Enter<LoadProgressState>();
    }
}