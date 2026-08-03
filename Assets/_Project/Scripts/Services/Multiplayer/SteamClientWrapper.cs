using System;
using Steamworks;

namespace _Project.Multiplayer
{
    public class SteamClientWrapper
    {
        public SteamClientWrapper()
        {
            SteamClient.Init(480);
        }

        public void Update() => SteamClient.RunCallbacks();

        public void Dispose() => SteamClient.Shutdown();
    }
}
