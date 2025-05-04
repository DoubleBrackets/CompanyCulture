using System.Collections.Generic;
using UnityEngine;

namespace PopupUI
{
    public class PopupWindow : MonoBehaviour
    {
        [SerializeField]
        private Transform _contentTransform;

        public Vector3 Position => transform.position;
        private List<HyperLink> _hyperLinks;

        private bool _isDragging;
        private Vector2 _draggingOffset;

        private void Awake()
        {
            SetupHyperlinks();
        }

        private void Update()
        {
            if (_isDragging)
            {
                Camera cam = Camera.main;
                Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector3 targetPosition = mousePosition + (Vector3)_draggingOffset;

                SetPosition(targetPosition);
            }
        }

        private void OnDestroy()
        {
            CleanupHyperlinks();
        }

        private void HandleOnClicked()
        {
            GetFocus();
        }

        public void ClosePopup()
        {
            Destroy(gameObject);
        }

        public void SetIsDragging(bool isDragging)
        {
            _isDragging = isDragging;

            if (isDragging)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = transform.position.z;
                _draggingOffset = (Vector2)transform.position - (Vector2)mousePosition;
                GetFocus();
            }
        }

        public void SetPosition(Vector3 position)
        {
            // clamp to screen bounds
            Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            position.x = Mathf.Clamp(position.x, -screenBounds.x, screenBounds.x);
            position.y = Mathf.Clamp(position.y, -screenBounds.y, screenBounds.y);

            position.z = transform.position.z;

            transform.position = position;
        }

        public void GetFocus()
        {
            transform.SetAsLastSibling();
        }

        public void InstantiateContent(GameObject contentPrefab)
        {
            if (_contentTransform == null)
            {
                Debug.LogError("Content transform is not assigned.");
                return;
            }

            foreach (Transform child in _contentTransform)
            {
                Destroy(child.gameObject);
            }

            GameObject contentInstance = Instantiate(contentPrefab, _contentTransform);

            // Search for all HyperLink components in the content
            CleanupHyperlinks();
            SetupHyperlinks();
        }

        private void SetupHyperlinks()
        {
            _hyperLinks = new List<HyperLink>(GetComponentsInChildren<HyperLink>());

            foreach (HyperLink link in _hyperLinks)
            {
                link.Initialize(this);
                link.OnClicked += HandleOnClicked;
            }
        }

        private void CleanupHyperlinks()
        {
            foreach (HyperLink link in _hyperLinks)
            {
                link.OnClicked -= HandleOnClicked;
            }

            _hyperLinks.Clear();
        }
    }
}