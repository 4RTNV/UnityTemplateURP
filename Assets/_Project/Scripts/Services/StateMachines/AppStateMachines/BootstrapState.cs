namespace _Project.States
{
    public class BootstrapState : IState
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
