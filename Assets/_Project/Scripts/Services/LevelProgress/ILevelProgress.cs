using System;

namespace _Project.CurrentLevelProgress
{
    public interface ILevelProgress
    {
        event EventHandler WaveCleared;
        event EventHandler LevelCleared;
        event EventHandler PlayerCoreDestroyed;
        LevelConfig LoadedLevelConfig { get; }
        bool IsLevelSuccessfullyFinished { get; }
        void LoadLevelConfig(LevelConfig levelConfig);
    }
}