using _Project.CurrentLevelProgress;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace _Project.StaticData
{
    public class ScriptableStaticData : IStaticData
    {
        private Dictionary<int, LevelConfig> _levels;
        private Texture2D _tileAtlas;
        private LineRenderer _wirePrefab;

        public void LoadStaticData()
        {
            _levels = Resources.LoadAll<LevelConfig>("Configs/Levels").ToDictionary(x => x.LevelID, x => x);
        }
        
        public LevelConfig ForLevel(int levelID)
            => _levels.GetValueOrDefault(levelID);
    }
}