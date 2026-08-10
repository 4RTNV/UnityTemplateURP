using System;

namespace _Project.Multiplayer
{
    public interface IMultiplayerClient : IDisposable
    {
        void Update();
    }
}
