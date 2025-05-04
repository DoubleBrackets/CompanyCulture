using UnityEngine;

namespace Feel
{
    public class ParticleScaleMatcher : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _referenceRectTransform;

        [SerializeField]
        private ParticleSystem _targetParticle;

        private short _particleCount;

        private void Awake()
        {
            _particleCount = _targetParticle.emission.GetBurst(0).maxCount;
        }

        public void ScaleMatch()
        {
            Vector2 sizeDelta = _referenceRectTransform.sizeDelta;
            float area = sizeDelta.x * sizeDelta.y;
            ParticleSystem.ShapeModule shape = _targetParticle.shape;
            shape.scale = new Vector3(
                sizeDelta.x,
                sizeDelta.y,
                1f
            );

            ParticleSystem.Burst zeroBurst = _targetParticle.emission.GetBurst(0);
            zeroBurst.maxCount = (short)(_particleCount * area);
        }
    }
}