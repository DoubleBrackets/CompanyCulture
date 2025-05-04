using System;
using Dev;
using UnityEditor;
using UnityEngine;

namespace PopupUI
{
    public class HyperLink : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _openedWindowOffset;

        [SerializeField]
        private PopupWindow _popupWindow;

        public event Action OnClicked;

        private void OnDrawGizmos()
        {
            if (_popupWindow == null)
            {
                return;
            }
#if UNITY_EDITOR
            Handles.Label(transform.position, _popupWindow.name, EditorUtil.HighVisLabel);
#endif
            // Draw bounds
            Gizmos.color = Color.yellow;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            Vector2 size = GetComponent<RectTransform>().sizeDelta;
            Gizmos.DrawWireCube(Vector3.zero, size);
            Gizmos.matrix = Matrix4x4.identity;
        }

        public void Initialize(PopupWindow popupWindow)
        {
            _popupWindow = popupWindow;
        }

        public void OpenPopup()
        {
            Debug.Log($"Opening popup: {_popupWindow.name}");
            if (_popupWindow == null)
            {
                Debug.LogError("PopupWindow is not assigned.");
                return;
            }

            OnClicked?.Invoke();

            // Instantiate the popup window prefab
            PopupWindow popupInstance = Instantiate(_popupWindow, _popupWindow.transform.parent);
            popupInstance.SetPosition(_popupWindow.Position + (Vector3)_openedWindowOffset);
        }
    }
}