using System.Collections.Generic;
using _Project.PersistentProgress;
using _Project.SaveLoad;
using _Project.SceneLoader;
using _Project.StaticData;

namespace _Project.StateMachines
{
    public sealed class AppStateFactory : IAppStateFactory
    {
        private readonly IPersistentProgress _progress;
        private readonly ISaveLoad _saveLoad;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticData _staticData;

        public AppStateFactory(ISceneLoader sceneLoader, IPersistentProgress progress, ISaveLoad saveLoad,
            IStaticData staticData)
        {
            _sceneLoader = sceneLoader;
            _progress = progress;
            _saveLoad = saveLoad;
            _staticData = staticData;
        }

        public IEnumerable<IExitableAppState> CreateStates(AppStateMachine stateMachine)
        {
            return new IExitableAppState[]
            {
                new BootstrapState(stateMachine, _sceneLoader),
                new LoadProgressState(stateMachine, _progress, _saveLoad),
                new LoadMainMenuState(stateMachine, _sceneLoader),
                new LoadLevelState(stateMachine, _progress, _staticData),
            };
        }
    }
}
