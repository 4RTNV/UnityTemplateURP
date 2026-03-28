namespace _Project.PersistentProgress
{
    public interface IProgressUpdater : ISavedProgressReader
    {
        void UpdateProgress(CurrentPlayerProgress progress);
    }
}