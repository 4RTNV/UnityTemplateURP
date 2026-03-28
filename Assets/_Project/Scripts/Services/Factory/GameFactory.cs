using UnityEngine;
using System.Collections.Generic;
using _Project.Data;
using _Project.AssetManagement;
using _Project.PlayerProgress;

namespace _Project.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IPersistentProgress _progress;

        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<IProgressUpdater> ProgressWriters { get; } = new()
        {
            Capacity = 0
        };

        public GameFactory(IAssetProvider assets, IPersistentProgress progress)
        {
            _assets = assets;
            _progress = progress;
        }
        
        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        public void LoadProgress(CurrentPlayerProgress progress)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProgress(CurrentPlayerProgress progress)
        {
            throw new System.NotImplementedException();
        }
    }
}
