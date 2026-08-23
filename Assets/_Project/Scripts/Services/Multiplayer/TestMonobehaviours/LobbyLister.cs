using Reflex.Attributes;
using UnityEngine;

namespace _Project.Multiplayer
{
    public class LobbyLister : MonoBehaviour
    {
        private ILobbiesCoordinator _coordinator;

        private void Start()
        {
            // GetLobbiesAsync().LogExceptionsAndForget();
        }

        private async Awaitable GetLobbiesAsync()
        {
            Debug.Log(await _coordinator.GetLobbiesAsync());
        }

        [Inject]
        public void Initialize(ILobbiesCoordinator coordinator)
        {
            _coordinator = coordinator;
        }
    }
}
