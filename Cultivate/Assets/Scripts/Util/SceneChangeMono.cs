using Managers;
using NaughtyAttributes;
using UnityEngine;

namespace Util
{
    public class SceneChangeMono : MonoBehaviour
    {
        [Scene]
        [SerializeField]
        private string _sceneName;

        public void ChangeScene()
        {
            SceneChanger.Instance.ChangeScene(_sceneName);
        }
    }
}