using Steamworks;
using UnityEngine;

namespace _Project.Multiplayer.Lobbies
{
    public class SteamLobbiesCoordinator
    {
        public async Awaitable<Lobby?> CreateLobbyAsync(Lobby targetLobby)
        {
            var nullableSteamLobby = await SteamMatchmaking.CreateLobbyAsync(4);
            if (nullableSteamLobby is not { } steamLobby) return null;

            steamLobby.SetData("Name", targetLobby.Name);
            targetLobby.Id = steamLobby.Id.ToString();
            return targetLobby;
        }

        public async Awaitable<Lobby?> JoinLobbyAsync(string targetId)
        {
            var steamLobby = await SteamMatchmaking.JoinLobbyAsync(ulong.Parse(targetId));
        }
    }
}
