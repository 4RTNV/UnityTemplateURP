using _Project.CurrentLevelProgress;

namespace _Project.StaticData
{
    public interface IStaticData
    {
        LevelConfig ForLevel(int levelID);
        void LoadStaticData();
    }
}
