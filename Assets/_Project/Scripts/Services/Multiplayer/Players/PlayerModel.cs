using Steamworks;
using UnityEngine;

namespace _Project.Multiplayer.Players.Steam
{
    public struct PlayerModel
    {
        public PlayerModel(Texture2D avatar, string id, string name, string nickname, bool playingSameGame,
            FriendState state)
        {
            Avatar = avatar;
            Id = id;
            Name = name;
            Nickname = nickname;
            PlayingSameGame = playingSameGame;
            State = state;
        }

        public Texture2D Avatar { get; internal set; }

        public string Id { get; }

        public string Name { get; internal set; }

        public string Nickname { get; internal set; }

        public bool PlayingSameGame { get; internal set; }

        public FriendState State { get; internal set; }

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
