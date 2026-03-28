using System;
using UnityEngine;
using System.Collections;
using _Project;
using UnityEngine.SceneManagement;

namespace _Project.SceneLoader
{
    public class AsyncSceneLoader : ISceneLoader
    {
        public AsyncSceneLoader()
        {
            Debug.Log("Created async scene loaded");
        }

        public IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            Debug.Log("Started loading...");
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);
            
            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}