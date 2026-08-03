using System.Threading.Tasks;
using Steamworks;
using Steamworks.Data;
using UnityEngine;
using Color = UnityEngine.Color;

namespace _Project.Multiplayer.Players.Steam.Steam
{
    public class PlayerModelTranslator
    {
        public async Task<PlayerModel> CreatePlayerModel(Friend friend)
        {
            var avatar = Texture2D.blackTexture;
            if (await friend.GetLargeAvatarAsync() is { } image) avatar = GetPlayerAvatarTexture(image);
            var playingSameGame = false;
            if (friend.GameInfo is { } gameInfo)
                playingSameGame = gameInfo.GameID == 480; // Inject game id? (Singleton it!!!!)

            return new PlayerModel(avatar, friend.Id.ToString(), friend.Name, friend.Nickname, playingSameGame,
                friend.State);
        }

        private static Texture2D GetPlayerAvatarTexture(Image image)
        {
            var avatar = new Texture2D((int)image.Width, (int)image.Height, TextureFormat.ARGB32, false)
            {
                filterMode = FilterMode.Trilinear
            };

            for (var x = 0; x < image.Width; x++)
            for (var y = 0; y < image.Height; y++)
            {
                var p = image.GetPixel(x, y);
                avatar.SetPixel(x, (int)image.Height - y,
                    new Color(p.r / 255.0f, p.g / 255.0f, p.b / 255.0f, p.a / 255.0f));
            }

            avatar.Apply();
            return avatar;
        }
    }
}
