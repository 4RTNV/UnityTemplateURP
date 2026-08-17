using _Project.AssetManagement;
using _Project.CurrentLevelProgress;
using _Project.Factory;
using _Project.Multiplayer;
using _Project.Multiplayer.Players;
using _Project.Multiplayer.Players.Steam;
using _Project.PersistentProgress;
using _Project.SaveLoad;
using _Project.SceneLoader;
using _Project.States;
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
            Debug.Log("Install Binding Started");
            InstallInfrastructureBindings(builder);
            InstallGameplayServices(builder);
            InstallUIBindings(builder);
            // InstallMultiplayerBindings(builder);

            builder.OnContainerBuilt += container => { container.Single<AppStateMachine>().Enter<BootstrapState>(); };
        }

        private static void InstallInfrastructureBindings(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(AssetProvider), new[] { typeof(IAssetProvider) }, Lifetime.Singleton,
                Resolution.Eager);
            builder.RegisterType(typeof(PersistentProgress.PersistentProgress), new[] { typeof(IPersistentProgress) },
                Lifetime.Singleton, Resolution.Eager);
            builder.RegisterType(typeof(PlayerPrefsSaveLoad), new[] { typeof(ISaveLoad) }, Lifetime.Singleton,
                Resolution.Eager);
            builder.RegisterType(typeof(ScriptableStaticData), new[] { typeof(IStaticData) }, Lifetime.Singleton,
                Resolution.Eager);
            builder.RegisterType(typeof(AsyncSceneLoader), new[] { typeof(ISceneLoader) }, Lifetime.Singleton,
                Resolution.Eager);
            builder.RegisterType(typeof(AppStateMachine), Lifetime.Singleton, Resolution.Eager);

            builder.RegisterType(typeof(GameFactory),
                new[] { typeof(IGameFactory), typeof(ISavedProgressReader), typeof(IProgressUpdater) }, Lifetime.Scoped,
                Resolution.Eager);
        }

        private static void InstallGameplayServices(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(LevelProgress), new[] { typeof(ILevelProgress) }, Lifetime.Scoped,
                Resolution.Eager);
            builder.RegisterType(typeof(InGameTimeService), new[] { typeof(IInGameTimeService) }, Lifetime.Scoped,
                Resolution.Eager);
        }

        private static void InstallUIBindings(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(UIFactory), new[] { typeof(IUIFactory) }, Lifetime.Scoped, Resolution.Eager);
        }

        private static void InstallMultiplayerBindings(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(SteamFriendsCatalog), new[] { typeof(IFriendsCatalog) }, Lifetime.Singleton,
                Resolution.Eager);
            builder.RegisterType(typeof(SteamClientWrapper), new[] { typeof(IMultiplayerClient) }, Lifetime.Singleton,
                Resolution.Eager);
        }
    }
}
