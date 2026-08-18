using Steamworks;
using UnityEngine;

namespace _Project.Multiplayer
{
    public class SteamClientWrapper : IMultiplayerClient
    {
        public SteamClientWrapper()
        {
            SteamClient.Init(480);
            Debug.Log($"Initializing SteamClient. Valid: {SteamClient.IsValid}, Connected: {SteamClient.IsLoggedOn}");
            Debug.Log($"{SteamClient.State}, {SteamClient.Name}, {SteamClient.AppId}");
        }

        public void Dispose()
        {
            SteamClient.Shutdown();
        }

        public void Update()
        {
            SteamClient.RunCallbacks();
        }
    }
}
