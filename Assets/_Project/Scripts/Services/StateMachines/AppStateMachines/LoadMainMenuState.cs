using _Project.SceneLoader;

namespace _Project.States
{
    public class LoadMainMenuState : IState
    {
        private readonly AppStateMachine _appStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadMainMenuState(AppStateMachine appStateMachine, ISceneLoader sceneLoader)
        {
            _appStateMachine = appStateMachine;
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
