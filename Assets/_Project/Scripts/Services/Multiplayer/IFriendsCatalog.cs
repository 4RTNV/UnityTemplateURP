using System;
using System.Collections.Generic;

namespace _Project.Multiplayer
{
    public interface IFriendsCatalog
    {
        event EventHandler<PlayerModel> FriendDetailsChanged;

        IAsyncEnumerable<PlayerModel> GetFriendsAsync();
    }
}
