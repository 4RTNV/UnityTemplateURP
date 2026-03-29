using System;

namespace _Project.TimeService
{
    public interface IInGameTimeService
    {
        event EventHandler<bool> GamePaused;
        void EnablePause();
        void RestoreTimePassage();
    }
}