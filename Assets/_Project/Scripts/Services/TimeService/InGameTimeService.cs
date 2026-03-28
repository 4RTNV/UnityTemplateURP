using System;
using UnityEngine;

namespace _Project.TimeService
{
    public class InGameTimeService : IInGameTimeService
    {
        public event EventHandler<bool> GamePaused = delegate { };

        public void EnablePause()
        {
            Time.timeScale = 0f;
            GamePaused(this, true);
        }

        public void RestoreTimePassage()
        {
            Time.timeScale = 1f;
            GamePaused(this, false);
        }
    }
}