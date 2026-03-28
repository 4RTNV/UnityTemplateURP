namespace _Project.PlayerProgress
{
    /// <summary>
    /// Service that provides access to player progress
    /// </summary>
    public interface IPersistentProgress 
    {
        CurrentPlayerProgress Progress { get; set; }
        void IncrementCurrentLevel();
    }
}