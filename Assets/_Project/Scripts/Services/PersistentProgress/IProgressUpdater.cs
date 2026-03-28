namespace _Project.Services.PlayerProgress
{
    public interface IProgressUpdater : ISavedProgressReader
    {
        void UpdateProgress(CurrentPlayerProgress progress);
    }
}