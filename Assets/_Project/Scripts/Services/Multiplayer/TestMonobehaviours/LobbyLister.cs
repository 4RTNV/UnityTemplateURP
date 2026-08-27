using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

namespace _Project.Multiplayer
{
    public class LobbyLister : MonoBehaviour
    {
        private readonly List<Lobby> _lobbies = new();
        private ILobbiesCoordinator _coordinator;

        private void Start()
        {
            GetLobbiesAsync().LogExceptionsAndForget();
            Debug.Log($"Lobbies Count: {_lobbies.Count}");
        }

        private async Awaitable GetLobbiesAsync()
        {
            await foreach (var lobby in _coordinator.GetLobbiesAsync())
                _lobbies.Add(lobby);
        }

        [Inject]
        public void Initialize(ILobbiesCoordinator coordinator)
        {
            _coordinator = coordinator;
        }
    }
}
