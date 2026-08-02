using System;

namespace _Project.PersistentProgress
{
    [Serializable]
    public class CurrentPlayerProgress
    {
        private int _currentLevel = 1;
        private bool _hasFinishedTutorial = false;

        public int CurrentLevel
        {
            get => _currentLevel;
            set => _currentLevel = value;
        }

        public bool HasFinishedTutorial
        {
            get => _hasFinishedTutorial;
            set => _hasFinishedTutorial = value;
        }

        public override string ToString() => $"Level={CurrentLevel};";
    }
}
