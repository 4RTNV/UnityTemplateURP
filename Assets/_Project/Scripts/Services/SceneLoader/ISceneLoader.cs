using System;
using System.Collections;

namespace _Project.SceneLoader
{
    public interface ISceneLoader
    {
        IEnumerator LoadScene(string name, Action onLoaded = null);
    }
}