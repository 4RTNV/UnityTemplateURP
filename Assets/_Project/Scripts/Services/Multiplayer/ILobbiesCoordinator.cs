using System.Collections.Generic;
using UnityEngine;

namespace _Project.Multiplayer
{
    public interface ILobbiesCoordinator
    {
        Awaitable<Lobby?> CreateLobbyAsync(Lobby targetLobby);

        Awaitable<Lobby?> JoinLobbyAsync(string targetId);

        Awaitable<IEnumerable<Lobby>> ListLobbiesAsync();
    }
}
