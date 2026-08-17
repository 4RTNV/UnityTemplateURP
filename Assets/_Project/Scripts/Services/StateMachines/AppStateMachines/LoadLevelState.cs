using _Project.PersistentProgress;
using _Project.StaticData;
using UnityEngine;

namespace _Project.StateMachines
{
    public class LoadLevelState : IPayloadedAppState<string>
    {
        private readonly AppStateMachine _appStateMachine;
        private readonly Canvas _loadingCurtain;
        private readonly IPersistentProgress _progress;
        private readonly IStaticData _staticData;

        public LoadLevelState(AppStateMachine appStateMachine, IPersistentProgress progress, IStaticData staticData)
        {
            _appStateMachine = appStateMachine;
            _progress = progress;
            _staticData = staticData;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.gameObject.SetActive(true);
        }

        public void Exit()
        {
            _loadingCurtain.gameObject.SetActive(false);
        }
    }
}
