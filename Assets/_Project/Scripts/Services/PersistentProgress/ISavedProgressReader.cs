using _Project.Data;

namespace _Project.PlayerProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(CurrentPlayerProgress progress);
    }
}