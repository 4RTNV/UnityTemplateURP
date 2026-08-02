using _Project.PersistentProgress;

namespace _Project.SaveLoad
{
    public interface ISaveLoad
    {
        CurrentPlayerProgress LoadProgress();
        void SaveProgress();
    }
}
