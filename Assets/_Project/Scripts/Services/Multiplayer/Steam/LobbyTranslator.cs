namespace _Project.Multiplayer.Steam
{
    internal static class LobbyTranslator
    {
        public static Lobby CreateLobby(Steamworks.Data.Lobby steamLobby)
        {
            return new Lobby
            {
                Id = steamLobby.Id.ToString(),
                Name = steamLobby.GetData("Name"),
                // Player Translation here, will require changing namespaces
            };
        }
    }
}
