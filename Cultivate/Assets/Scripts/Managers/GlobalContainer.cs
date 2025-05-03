using UnityEngine;

namespace Managers
{
    public class GlobalContainer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _globalPrefab;

        public static GlobalContainer Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                if (_globalPrefab != null)
                {
                    Instantiate(_globalPrefab, transform);
                }

                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}