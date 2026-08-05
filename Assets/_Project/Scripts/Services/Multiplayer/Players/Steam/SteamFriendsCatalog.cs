using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Steamworks;

namespace _Project.Multiplayer.Players.Steam
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
            foreach (var friend in SteamFriends.GetFriends())
                yield return await PlayerModelTranslator.CreatePlayerModel(friend);
        }

        private async Task OnFriendDetailsChanged(Friend friend)
        {
            FriendDetailsChanged?.Invoke(this, await PlayerModelTranslator.CreatePlayerModel(friend));
        }
    }
}
