using System.Collections.Generic;
using _Project.Multiplayer.Players;

namespace _Project.Multiplayer.Lobbies
{
    public struct Lobby
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<PlayerModel> Players { get; set; }
    }
}
