using System.Linq;
using UnityEngine;

namespace _Project.Multiplayer.Steam
{
    internal static class LobbyTranslator
    {
        public static async Awaitable<Lobby?> CreateLobby(Steamworks.Data.Lobby? steamLobbyNullable)
        {
            if (steamLobbyNullable is not { } steamLobby) return null;

            // I wish I could use LINQ..
            var steamPlayers = steamLobby.Members.ToArray();
            var players = new PlayerModel[steamPlayers.Length];
            for (var i = 0; i < players.Length; i++)
                players[i] = await PlayerModelTranslator.CreatePlayerModel(steamPlayers.ElementAt(i));

            return new Lobby
            {
                Id = steamLobby.Id.ToString(),
                Name = steamLobby.GetData("Name"),
                Players = players,
            };
        }
    }
}
