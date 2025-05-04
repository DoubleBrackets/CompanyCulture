using System;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class CursorManager : MonoBehaviour
    {
        public enum CursorTypes
        {
            Default,
            Grab,
            Click,
            Write
        }

        [Serializable]
        public struct CursorConfig
        {
            public CursorTypes Type;
            public Sprite Texture;
            public Vector2 Hotspot;
        }

        public static CursorManager Instance;

        [SerializeField]
        private Image _cursorImage;

        [SerializeField]
        private CursorConfig[] _cursors;

        private void Awake()
        {
            Instance = this;
            Cursor.visible = false;
        }

        private void Update()
        {
            Vector3 mousePos = Input.mousePosition;
            _cursorImage.rectTransform.anchoredPosition = mousePos;
        }

        public void SetCursor(CursorTypes cursorType)
        {
            CursorConfig cursorConfig = Array.Find(_cursors, c => c.Type == cursorType);
            if (cursorConfig.Texture != null)
            {
                // Cursor.SetCursor(cursorConfig.Texture, cursorConfig.Hotspot, CursorMode.Auto);
                _cursorImage.sprite = cursorConfig.Texture;
            }
            else
            {
                Debug.LogError($"Cursor texture for {cursorType} not found.");
            }
        }
    }
}