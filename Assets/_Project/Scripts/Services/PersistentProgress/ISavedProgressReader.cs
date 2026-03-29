namespace _Project.PersistentProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(CurrentPlayerProgress progress);
    }
}