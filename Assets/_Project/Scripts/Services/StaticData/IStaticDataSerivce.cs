using _Project.Services.CurrentLevelProgress;

namespace _Project.StaticData
{
    public interface IStaticData
    {
        void LoadStaticData();
        LevelConfig ForLevel(int levelID);
    }
}