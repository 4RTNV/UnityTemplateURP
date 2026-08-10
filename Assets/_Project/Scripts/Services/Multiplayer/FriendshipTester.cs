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
        private List<PlayerModel> _friends;

        public void Start()
        {
            Debug.Log($"{_catalog!}, {_friends!}");
        }

        [Inject]
        public async Task Initialize(IFriendsCatalog friendsCatalog)
        {
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
