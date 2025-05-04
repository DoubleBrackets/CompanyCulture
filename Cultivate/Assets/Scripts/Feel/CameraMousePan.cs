using Unity.Cinemachine;
using UnityEngine;

namespace Feel
{
    /// <summary>
    ///     Pans the mouse slightly
    /// </summary>
    public class CameraMousePan : MonoBehaviour
    {
        [SerializeField]
        private CinemachineCameraOffset _offset;

        [SerializeField]
        private float _xAmount;

        [SerializeField]
        private float _yAmount;

        private void Update()
        {
            if (_offset.ComponentOwner.enabled == false)
            {
                return;
            }

            Vector2 mousePos = Input.mousePosition;

            Vector2 normalizedMousePos = mousePos / new Vector2(Screen.width, Screen.height);

            Vector2 normalizedOffset = new Vector2(
                normalizedMousePos.x - 0.5f,
                normalizedMousePos.y - 0.5f
            ) * 2f;

            _offset.Offset.x = normalizedOffset.x * _xAmount;
            _offset.Offset.y = normalizedOffset.y * _yAmount;
        }
    }
}