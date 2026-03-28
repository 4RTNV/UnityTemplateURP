using System.Collections.Generic;
using _Project.PlayerProgress;

namespace _Project.Factory
{
    public interface IGameFactory : IProgressUpdater
    {
        List<ISavedProgressReader> ProgressReaders { get; } 
        List<IProgressUpdater> ProgressWriters { get; }
        void CleanUp();
    }
}