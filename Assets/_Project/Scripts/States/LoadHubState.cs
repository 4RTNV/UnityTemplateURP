using _Project.SceneLoader;

namespace _Project.States
{
    public class LoadHubState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadHubState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            SingletonCoroutineRunner.Instance.StartCoroutine(_sceneLoader.LoadScene(SceneNames.MenuSceneName,
                OnHubSceneLoaded));
        }

        public void Exit()
        {
        }

        private void OnHubSceneLoaded()
        {
        }
    }
}
