namespace _Project.CurrentLevelProgress
{
    public class LevelProgress : ILevelProgress
    {
        private LevelConfig _loadedLevelConfig;
        public LevelConfig LoadedLevelConfig => _loadedLevelConfig;

        public void LoadLevelConfig(LevelConfig levelConfig)
        {
            _loadedLevelConfig = levelConfig;
        }
    }
}