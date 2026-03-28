namespace _Project.PersistentProgress
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