using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Multiplayer
{
    public interface IFriendsCatalog
    {
        event EventHandler<PlayerModel> FriendDetailsChanged;

        Awaitable<IEnumerable<PlayerModel>> GetFriendsAsync();
    }
}
