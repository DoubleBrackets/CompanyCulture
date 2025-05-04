using Managers;
using SelectionUI;
using UnityEngine;
using UnityEngine.Serialization;

namespace DetailsUI
{
    /// <summary>
    ///     Loads the portrait card in the details screen
    /// </summary>
    public class DetailsCardLoader : MonoBehaviour
    {
        [SerializeField]
        private GameStateSO _gameStateSO;

        [FormerlySerializedAs("_candidateCard")]
        [SerializeField]
        private CandidateSelectionZone candidateSelectionZone;

        private void Awake()
        {
            // _candidateCard.Initialize(_gameStateSO.ExaminedCandidate);
        }
    }
}