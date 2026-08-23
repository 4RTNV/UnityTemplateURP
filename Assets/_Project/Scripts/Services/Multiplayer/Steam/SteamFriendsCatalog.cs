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

        public async Awaitable<IEnumerable<PlayerModel>> GetFriendsAsync()
        {
            var friendsArray = SteamFriends.GetFriends().ToArray();
            var friendsList = new List<PlayerModel>();
            foreach (var friend in friendsArray)
            {
                var playerModel = await PlayerModelTranslator.CreatePlayerModel(friend);
                friendsList.Add(playerModel);
            }

            return friendsList;
        }

        private async Awaitable OnFriendDetailsChanged(Friend friend)
        {
            FriendDetailsChanged?.Invoke(this, await PlayerModelTranslator.CreatePlayerModel(friend));
        }
    }
}
