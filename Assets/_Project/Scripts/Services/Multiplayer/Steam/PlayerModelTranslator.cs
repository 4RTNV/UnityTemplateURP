using Steamworks;
using UnityEngine;

namespace _Project.Multiplayer.Steam
{
    internal static class PlayerModelTranslator
    {
        public static async Awaitable<PlayerModel> CreatePlayerModel(Friend friend)
        {
            await Awaitable.MainThreadAsync();
            var playingSameGame = false;
            var avatar = Texture2D.whiteTexture;
            var image = await friend.GetLargeAvatarAsync();
            await Awaitable.MainThreadAsync();
            if (image != null)
                avatar = CreateTextureFromRawBytes(image.Value.Data, (int)image.Value.Width, (int)image.Value.Height);

            if (friend.GameInfo is { } gameInfo)
                playingSameGame = gameInfo.GameID == SteamClient.AppId;
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
