using System;

namespace _Project.PersistentProgress
{
    [Serializable]
    public class CurrentPlayerProgress
    {
        public bool HasFinishedTutorial = false;
        public int CurrentLevel = 1;

        public override string ToString() 
            => $"Level={CurrentLevel};";
    } 
}
