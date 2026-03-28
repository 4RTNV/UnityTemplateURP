namespace _Project.PlayerProgress
{
    public interface IProgressUpdater : ISavedProgressReader
    {
        void UpdateProgress(CurrentPlayerProgress progress);
    }
}