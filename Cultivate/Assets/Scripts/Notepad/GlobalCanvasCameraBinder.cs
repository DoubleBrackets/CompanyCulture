using UnityEngine;

namespace Managers
{
    public class GlobalCanvasCameraBinder : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvas;

        private void Update()
        {
            if (canvas.worldCamera == null)
            {
                canvas.worldCamera = Camera.main;
            }
        }
    }
}