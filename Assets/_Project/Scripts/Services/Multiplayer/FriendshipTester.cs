using System.Collections.Generic;
using System.Linq;
using _Project.Multiplayer.Players;
using Reflex.Attributes;
using UnityEngine;

namespace _Project.Multiplayer
{
    public class FriendshipTester : MonoBehaviour
    {
        private IFriendsCatalog _catalog;
        private IMultiplayerClient _client;
        private List<PlayerModel> _friends = new();

        private void Update()
        {
            _client?.Update();
        }

        [Inject]
        public void Initialize(IMultiplayerClient client, IFriendsCatalog catalog)
        {
            _client = client;
            _catalog = catalog;
            CreateFriendsList().LogExceptionsAndForget();
        }

        private async Awaitable CreateFriendsList()
        {
            await foreach (var friend in _catalog.GetFriendsAsync()) _friends.Add(friend);
            Debug.Log($"FriendshipTester initialized with {_friends.Count} friends");
            _catalog.FriendDetailsChanged += (sender, model) =>
            {
                Debug.Log($"FriendshipTester: Friend details changed: {model.Name}");
                _friends = _friends.Select(f => f.Equals(model) ? model : f).ToList();
            };
        }
    }
}
