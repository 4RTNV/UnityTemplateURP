using System.Threading.Tasks;
using Steamworks;
using UnityEngine;

namespace _Project.Multiplayer.Players.Steam
{
    internal static class PlayerModelTranslator
    {
        public static async Task<PlayerModel> CreatePlayerModel(Friend friend)
        {
            var playingSameGame = false;
            var avatar = Texture2D.whiteTexture;
            var image = await friend.GetLargeAvatarAsync();
            if (image != null)
                avatar = CreateTextureFromRawBytes(image.Value.Data, (int)image.Value.Width, (int)image.Value.Height);
            if (friend.GameInfo is { } gameInfo) playingSameGame = gameInfo.GameID == SteamClient.AppId;
            return new PlayerModel(avatar, friend.Id.ToString(), friend.Name, friend.Nickname, playingSameGame,
                friend.State);
        }

        private static Texture2D CreateTextureFromRawBytes(byte[] rawBytes, int width, int height)
        {
            var tex = new Texture2D(width, height, TextureFormat.RGBA32, false)
            {
                filterMode = FilterMode.Trilinear,
            };

            tex.LoadRawTextureData(rawBytes);
            tex.Apply();

            return tex;
        }
    }
}
