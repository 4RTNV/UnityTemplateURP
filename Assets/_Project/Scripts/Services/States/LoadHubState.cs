using System;
using _Project.Infrastructure;
using _Project.Services.AssetManagement;
using _Project.Services.SceneLoader;
using _Project.UI.Views;

namespace _Project.Services.States
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

        public void Exit()
        {
        }

        private void OnHubSceneLoaded()
        {
            
        }

        public void Enter()
        {
            SingletonCoroutineRunner.Instance.StartCoroutine(
                _sceneLoader.LoadScene(SceneNames.MenuSceneName, onLoaded: OnHubSceneLoaded));
        }
    }
}