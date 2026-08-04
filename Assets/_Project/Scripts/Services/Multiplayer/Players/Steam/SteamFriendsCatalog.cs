using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Steamworks;

namespace _Project.Multiplayer.Players.Steam.Steam
{
    public class SteamFriendsCatalog : IFriendsCatalog
    {
        private readonly PlayerModelTranslator _translator;

        public SteamFriendsCatalog()
        {
            _translator = new PlayerModelTranslator();

            SteamFriends.OnPersonaStateChange += friend => { _ = OnFriendDetailsChanged(friend); }; // spooky!!
        }

        public event EventHandler<PlayerModel> FriendDetailsChanged;

        public async IAsyncEnumerable<PlayerModel> GetFriendsAsync()
        {
            foreach (var friend in SteamFriends.GetFriends())
                yield return await _translator.CreatePlayerModel(friend);
        }

        private async Task OnFriendDetailsChanged(Friend friend)
        {
            FriendDetailsChanged?.Invoke(this, await _translator.CreatePlayerModel(friend));
        }
    }
}
