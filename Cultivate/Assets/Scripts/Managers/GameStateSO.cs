using Gameplay;
using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "GameStateSO", menuName = "GameStateSO")]
    public class GameStateSO : ScriptableObject
    {
        [field: SerializeField]
        public CandidateSO ExaminedCandidate { get; set; }
    }
}