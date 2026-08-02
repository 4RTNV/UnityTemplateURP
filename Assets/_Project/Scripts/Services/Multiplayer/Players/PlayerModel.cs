using Steamworks;
using UnityEngine;

namespace _Project.Multiplayer.Players.Steam
{
    public struct PlayerModel
    {
        public Texture2D Avatar { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public bool PlayingSameGame { get; set; }

        public FriendState State { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is PlayerModel player) return Id.Equals(player.Id);

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
