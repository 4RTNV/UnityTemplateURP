using _Project.Services.PlayerProgress;

namespace _Project.Infrastructure.SaveLoad
{
    public interface ISaveLoad 
    {
        void SaveProgress();
        CurrentPlayerProgress LoadProgress();
    }
}