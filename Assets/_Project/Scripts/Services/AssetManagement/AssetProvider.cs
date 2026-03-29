using Unity.Mathematics;
using UnityEngine;

namespace _Project.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public T Instantiate<T>(string path) where T : MonoBehaviour 
            => Object.Instantiate(Resources.Load<T>(path));

        public T Instantiate<T>(string path, Vector3 at) where T : MonoBehaviour 
            => Object.Instantiate(Resources.Load<T>(path), at, Quaternion.identity);
        
        public T Instantiate<T>(string path, Transform parent) where T : MonoBehaviour
            => Object.Instantiate(Resources.Load<T>(path), parent);

        public T Instantiate<T>(T prefab, Vector3 position) where T : MonoBehaviour
            => Object.Instantiate(prefab, position, quaternion.identity);
        
        public T Instantiate<T>(T prefab, Transform parent) where T : MonoBehaviour
            => Object.Instantiate(prefab, parent);

        public GameObject Instantiate(string path) 
            => Object.Instantiate(Resources.Load<GameObject>(path));

        public GameObject Instantiate(string path, Vector3 at) 
            => Object.Instantiate(Resources.Load<GameObject>(path), at, Quaternion.identity);

        public GameObject Instantiate(string path, Transform parent)
            => Object.Instantiate(Resources.Load<GameObject>(path), parent);
    }
}