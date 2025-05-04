using UnityEngine;

namespace Persuasion
{
    public class PersuasionPortrait : MonoBehaviour
    {
        [SerializeField]
        private Transform _portraitTransform;

        [SerializeField]
        public Vector2 _zoomRange;

        public void SetZoom(float normalizedZoomAmount)
        {
            Debug.Log($"Zooming to {normalizedZoomAmount}");
            float zoom = Mathf.Lerp(_zoomRange.x, _zoomRange.y, normalizedZoomAmount);
            float scale = Mathf.Pow(2, zoom);
            _portraitTransform.localScale = new Vector3(scale, scale, 1);
        }
    }
}