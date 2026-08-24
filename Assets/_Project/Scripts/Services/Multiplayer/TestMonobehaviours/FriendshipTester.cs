using System.Collections.Generic;
using Reflex.Attributes;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

namespace _Project.Multiplayer
{
    public class FriendshipTester : MonoBehaviour
    {
        private IFriendsCatalog _catalog;
        private IMultiplayerClient _client;
        private List<PlayerModel> _friends = new();

        private void Start()
        {
            if (_client == null)
            {
                Debug.LogError("Client is missing");
                return;
            }

            CallForAvatars().LogExceptionsAndForget();
        }

        private void Update()
        {
            if (_client == null)
                Debug.LogError("Client is missing");
            _client?.Update();
        }

        [Inject]
        public void Initialize(IMultiplayerClient client, IFriendsCatalog catalog)
        {
            _client = client;
            _catalog = catalog;
            //CreateFriendsList().LogExceptionsAndForget();
        }

        /*private async Awaitable CreateFriendsList()
        {
            _friends = (await _catalog.GetFriendsAsync()).ToList();
            Debug.Log($"FriendshipTester initialized with {_friends.Count} friends");
            _catalog.FriendDetailsChanged += (sender, model) =>
            {
                Debug.Log($"FriendshipTester: Friend details changed: {model.Name}");
                _friends = _friends.Select(f => f.Equals(model) ? model : f).ToList();
            };
        }*/

        private async Awaitable CallForAvatars()
        {
            var friends = SteamFriends.GetFriends();
            var avatars = new List<Image>();
            foreach (var friend in friends)
            {
                var avatar = await friend.GetLargeAvatarAsync();
                if (avatar is { } avatarValue)
                    avatars.Add(avatarValue);
                await Awaitable.NextFrameAsync();
            }

            /*var avatar = await SteamFriends.GetLargeAvatarAsync(76561198449719972);
            if (avatar is { } avatarValue)
                avatars.Add(avatarValue);*/

            Debug.Log($"Got all {avatars.Count} avatars.");
        }
    }
}
