using System.Collections.Generic;
using _Project.PersistentProgress;

namespace _Project.Factory
{
    public interface IGameFactory : IProgressUpdater
    {
        List<ISavedProgressReader> ProgressReaders { get; } 
        List<IProgressUpdater> ProgressWriters { get; }
        void CleanUp();
    }
}