using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using UnityEngine;

namespace _Project.Multiplayer.Steam
{
    public class SteamFriendsCatalog : IFriendsCatalog
    {
        public SteamFriendsCatalog()
        {
            SteamFriends.OnPersonaStateChange += friend => { OnFriendDetailsChanged(friend).LogExceptionsAndForget(); };
        }

        public event EventHandler<PlayerModel> FriendDetailsChanged;

        public async IAsyncEnumerable<PlayerModel> GetFriendsAsync()
        {
            var friendsArray = SteamFriends.GetFriends().ToArray();
            foreach (var friend in friendsArray)
            {
                var playerModel = await PlayerModelTranslator.CreatePlayerModel(friend);
                yield return playerModel;
            }
        }

        private async Awaitable OnFriendDetailsChanged(Friend friend)
        {
            FriendDetailsChanged?.Invoke(this, await PlayerModelTranslator.CreatePlayerModel(friend));
        }
    }
}
