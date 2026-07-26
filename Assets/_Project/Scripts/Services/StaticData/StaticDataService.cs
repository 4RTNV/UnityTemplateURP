using System.Collections.Generic;
using System.Linq;
using _Project.CurrentLevelProgress;
using UnityEngine;

namespace _Project.StaticData
{
    public class ScriptableStaticData : IStaticData
    {
        private Dictionary<int, LevelConfig> _levels;
        private Texture2D _tileAtlas;
        private LineRenderer _wirePrefab;

        public LevelConfig ForLevel(int levelID)
        {
            return _levels.GetValueOrDefault(levelID);
        }

        public void LoadStaticData()
        {
            _levels = Resources.LoadAll<LevelConfig>("Configs/Levels").ToDictionary(x => x.LevelID, x => x);
        }
    }
}
