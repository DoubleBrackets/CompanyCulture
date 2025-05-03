using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneChanger : MonoBehaviour
    {
        public static SceneChanger Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ChangeScene(string sceneName)
        {
            Debug.Log($"Changing scene to: {sceneName}");
            SceneManager.LoadScene(sceneName);
        }
    }
}