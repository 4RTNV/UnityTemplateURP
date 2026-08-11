using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Project.Multiplayer.Players;
using Reflex.Attributes;
using UnityEngine;

namespace _Project.Multiplayer
{
    public class FriendshipTester : MonoBehaviour
    {
        private IFriendsCatalog _catalog;
        private IMultiplayerClient _client;
        private List<PlayerModel> _friends;

        public void Start()
        {
            Debug.Log($"{_catalog!}, {_friends!}");
        }

        private void Update()
        {
            _client?.Update();
        }

        [Inject]
        public async Task Initialize(IMultiplayerClient client, IFriendsCatalog friendsCatalog)
        {
            _client = client;
            _catalog = friendsCatalog;
            await foreach (var friend in friendsCatalog.GetFriendsAsync()) _friends.Add(friend);
            Debug.Log($"FriendshipTester initialized with {_friends.Count} friends");
            _catalog.FriendDetailsChanged += (sender, model) =>
            {
                Debug.Log($"FriendshipTester: Friend details changed: {model}");
                _friends = _friends.Select(f => f.Equals(model) ? model : f).ToList();
            };
        }
    }
}
