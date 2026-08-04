using System;
using System.Collections.Generic;

namespace _Project.Multiplayer.Players.Steam.Steam
{
    public interface IFriendsCatalog
    {
        event EventHandler<PlayerModel> FriendDetailsChanged;

        IAsyncEnumerable<PlayerModel> GetFriendsAsync();
    }
}
