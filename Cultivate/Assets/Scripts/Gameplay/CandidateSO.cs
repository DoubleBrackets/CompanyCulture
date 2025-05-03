using NaughtyAttributes;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "CandidateSO")]
    public class CandidateSO : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        [field: ShowAssetPreview]
        public Sprite Portrait { get; private set; }

        [field: SerializeField]
        [field: ShowAssetPreview]
        public GameObject DetailsPrefab { get; private set; }
    }
}