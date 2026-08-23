using System.Collections.Generic;
using System.Linq;
using Steamworks;
using UnityEngine;

namespace _Project.Multiplayer.Steam
{
    public class SteamLobbiesCoordinator : ILobbiesCoordinator
    {
        public async Awaitable<Lobby?> CreateLobbyAsync(Lobby targetLobby)
        {
            var nullableSteamLobby = await SteamMatchmaking.CreateLobbyAsync(4);
            if (nullableSteamLobby is not { } steamLobby) return null;

            steamLobby.SetData("Name", targetLobby.Name);
            targetLobby.Id = steamLobby.Id.ToString();
            return targetLobby;
        }

        public async Awaitable<IEnumerable<Lobby>> GetLobbiesAsync()
        {
            // TODO: add filters
            var steamLobbies = (await SteamMatchmaking.LobbyList.RequestAsync()).ToArray();

            var lobbies = new List<Lobby>();
            foreach (var steamLobby in steamLobbies)
            {
                if (await LobbyTranslator.CreateLobby(steamLobby) is not { } lobby) continue;

                lobbies.Add(lobby);
            }

            return lobbies;
        }

        public async Awaitable<Lobby?> JoinLobbyAsync(string targetId)
        {
            var steamLobby = await SteamMatchmaking.JoinLobbyAsync(ulong.Parse(targetId));
            return await LobbyTranslator.CreateLobby(steamLobby);
        }
    }
}
