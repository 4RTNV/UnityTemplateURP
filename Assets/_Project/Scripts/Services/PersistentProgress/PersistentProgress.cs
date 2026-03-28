namespace _Project.PlayerProgress
{
    public class PersistentProgress : IPersistentProgress
    {
        public CurrentPlayerProgress Progress { get; set; }

        public void IncrementCurrentLevel()
        {
            Progress.CurrentLevel++;
        }
    }
}