using System;
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
using Reflex.Enums;
using UnityEngine;
using Resolution = Reflex.Enums.Resolution;

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
            // Singleton bindings - Eager
            builder.RegisterType(typeof(AssetProvider), new Type[] { typeof(IAssetProvider) }, Lifetime.Singleton,
                Resolution.Eager);
            builder.RegisterType(typeof(PersistentProgress.PersistentProgress),
                new Type[] { typeof(IPersistentProgress) }, Lifetime.Singleton, Resolution.Eager);
            builder.RegisterType(typeof(PlayerPrefsSaveLoad), new Type[] { typeof(ISaveLoad) }, Lifetime.Singleton,
                Resolution.Eager);
            builder.RegisterType(typeof(ScriptableStaticData), new Type[] { typeof(IStaticData) }, Lifetime.Singleton,
                Resolution.Eager);
            builder.RegisterType(typeof(AsyncSceneLoader), new Type[] { typeof(ISceneLoader) }, Lifetime.Singleton,
                Resolution.Eager);
            builder.RegisterType(typeof(GameStateMachine), new Type[] { }, Lifetime.Singleton, Resolution.Eager);

            // Scoped bindings - Eager
            builder.RegisterType(typeof(GameFactory),
                new Type[] { typeof(IGameFactory), typeof(ISavedProgressReader), typeof(IProgressUpdater) },
                Lifetime.Scoped, Resolution.Eager);
            builder.RegisterType(typeof(UIFactory), new Type[] { typeof(IUIFactory) }, Lifetime.Scoped,
                Resolution.Eager);
            builder.RegisterType(typeof(LevelProgress), new Type[] { typeof(ILevelProgress) }, Lifetime.Scoped,
                Resolution.Eager);
            builder.RegisterType(typeof(InGameTimeService), new Type[] { typeof(IInGameTimeService) }, Lifetime.Scoped,
                Resolution.Eager);

            builder.OnContainerBuilt += container => { container.Single<GameStateMachine>().Enter<BootstrapState>(); };
        }
    }
}