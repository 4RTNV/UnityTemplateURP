using Steamworks;

namespace _Project.Multiplayer
{
    public class SteamClientWrapper : IMultiplayerClient
    {
        public SteamClientWrapper()
        {
            SteamClient.Init(480);
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
