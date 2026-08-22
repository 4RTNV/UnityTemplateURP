using System.Collections.Generic;

namespace _Project.Multiplayer
{
    public struct Lobby
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<PlayerModel> Players { get; set; }
    }
}
