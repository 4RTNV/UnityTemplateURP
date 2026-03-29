using System.Collections.Generic;
using _Project.Factory;
using _Project.PersistentProgress;
using UnityEngine;

namespace _Project.SaveLoad
{
    public class PlayerPrefsSaveLoad : ISaveLoad
    {
        private const string ProgressKey = "Progress";

        private readonly IPersistentProgress _progress;
        private readonly IGameFactory _gameFactory;
        private readonly IEnumerable<IProgressUpdater> _savedServices;
        private readonly List<IProgressUpdater> _saveWriterServices;

        public PlayerPrefsSaveLoad(IPersistentProgress progress, IGameFactory gameFactory, IEnumerable<IProgressUpdater> savedServices)
        {
            _progress = progress;
            _gameFactory = gameFactory;
            _savedServices = savedServices;
        }

        public CurrentPlayerProgress LoadProgress() => PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<CurrentPlayerProgress>();

        public void SaveProgress()
        {
            foreach (var progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progress.Progress);

            foreach (var writerService in _saveWriterServices)
                writerService.UpdateProgress(_progress.Progress);

            PlayerPrefs.SetString(ProgressKey, _progress.Progress.ToJson());
        }
    }
}