using System;

namespace _Project.CurrentLevelProgress
{
    public class LevelProgress : ILevelProgress
    {
        public event EventHandler WaveCleared = delegate { };
        public event EventHandler LevelCleared = delegate { };
        public event EventHandler PlayerCoreDestroyed = delegate { };

        private readonly IStaticData _staticData;
        private LevelConfig _loadedLevelConfig;
        
        private int _mobsLeftThisWave;
        private int _currentWaveIndex;
        private bool _isLastWave;

        public LevelConfig LoadedLevelConfig => _loadedLevelConfig;

        public bool IsLevelSuccessfullyFinished { get; private set; }

        public LevelProgress(IStaticData staticData)
        {
            _staticData = staticData;
        }

        public void LoadLevelConfig(LevelConfig levelConfig)
        {
            IsLevelSuccessfullyFinished = false;
            _loadedLevelConfig = levelConfig;
            _currentWaveIndex = 0;
            _isLastWave = false;
        }
    }
}