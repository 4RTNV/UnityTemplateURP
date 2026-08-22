using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Steamworks;

namespace _Project.Multiplayer.Steam
{
    public class SteamFriendsCatalog : IFriendsCatalog
    {
        public SteamFriendsCatalog()
        {
            SteamFriends.OnPersonaStateChange += friend => { _ = OnFriendDetailsChanged(friend); }; // spooky!!
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

        private async Task OnFriendDetailsChanged(Friend friend)
        {
            FriendDetailsChanged?.Invoke(this, await PlayerModelTranslator.CreatePlayerModel(friend));
        }
    }
}
