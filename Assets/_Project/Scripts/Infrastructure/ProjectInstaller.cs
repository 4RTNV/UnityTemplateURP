using _Project.SaveLoad;
using _Project.SceneLoader;
using _Project.AssetManagement;
using _Project.CurrentLevelProgress;
using _Project.Factory;
using _Project.States;
using _Project.PersistentProgress;
using _Project.StaticData;
using _Project.TimeService;
using _Project.UI.Factory;
using Reflex.Core;
using UnityEngine;

namespace _Project.Infrastructure
{
    /// <summary>
    /// Defines the bindings to the root global container
    /// </summary>
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        /// <summary>
        /// Reflex looks for & uses IInstaller instance to build a DI container
        /// </summary>
        public void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(typeof(AssetProvider), typeof(IAssetProvider));
            builder.AddSingleton(typeof(PersistentProgress.PersistentProgress), typeof(IPersistentProgress));
            builder.AddSingleton(typeof(PlayerPrefsSaveLoad), typeof(ISaveLoad));
            builder.AddSingleton(typeof(ScriptableStaticData), typeof(IStaticData));
            builder.AddSingleton(typeof(AsyncSceneLoader), typeof(ISceneLoader));

            builder.AddScoped(typeof(GameFactory), typeof(IGameFactory), typeof(ISavedProgressReader),
                typeof(IProgressUpdater));
            builder.AddScoped(typeof(UIFactory), typeof(IUIFactory));
            builder.AddScoped(typeof(LevelProgress), typeof(ILevelProgress));
            builder.AddScoped(typeof(InGameTimeService), typeof(IInGameTimeService));
            
            builder.AddSingleton(typeof(GameStateMachine));
            builder.OnContainerBuilt += container =>
            {
                container.Single<GameStateMachine>().Enter<BootstrapState>();
            };
        }
    }
}