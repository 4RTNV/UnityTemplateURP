using UnityEngine;

namespace _Project.CurrentLevelProgress
{
    [CreateAssetMenu(fileName = "Level_", menuName = "Config/LevelConfig", order = 2)]
    public class LevelConfig : ScriptableObject
    {
        [Header("=== LEVEL ===")]
        [SerializeField] private int levelID = 0;
        [SerializeField] private int initialMoney = 0;
        [Header("Core/generator parameters")]
        [SerializeField] private int coreHealth;
        [SerializeField] private float generatorCurrentGenerationPerSecond;
        [SerializeField] private float deltaBetweenSpawns;
        [Header("Building options")]
        [SerializeField] private int[] sentryIDs;
        [SerializeField] private int[] buildingIDs;

        public int LevelID => levelID;
        public int InitialMoney => initialMoney;
        public int CoreHealth => coreHealth;
        public int[] SentryIDs => sentryIDs;
        public float GeneratorCapacity => generatorCurrentGenerationPerSecond;
        public float DeltaBetweenSpawns => deltaBetweenSpawns;

        public int[] BuildingIDs => buildingIDs;
    }
}