using _Project.PersistentProgress;

namespace _Project.SaveLoad
{
    public interface ISaveLoad 
    {
        void SaveProgress();
        CurrentPlayerProgress LoadProgress();
    }
}