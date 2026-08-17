using _Project.SceneLoader;

namespace _Project.StateMachines
{
    public class BootstrapState : IAppState
    {
        private readonly AppStateMachine _appStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(AppStateMachine appStateMachine, ISceneLoader sceneLoader)
        {
            _appStateMachine = appStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            SingletonCoroutineRunner.Instance.StartCoroutine(_sceneLoader.LoadScene(SceneNames.BootstrapSceneName,
                EnterHub));
        }

        public void Exit()
        {
        }

        private void EnterHub()
        {
            _appStateMachine.Enter<LoadProgressState>();
        }
    }
}
