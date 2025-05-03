using Managers;
using SelectionUI;
using UnityEngine;

namespace DetailsUI
{
    /// <summary>
    ///     Loads the portrait card in the details screen
    /// </summary>
    public class DetailsCardLoader : MonoBehaviour
    {
        [SerializeField]
        private GameStateSO _gameStateSO;

        [SerializeField]
        private CandidateCard _candidateCard;

        private void Awake()
        {
            _candidateCard.Initialize(_gameStateSO.ExaminedCandidate);
        }
    }
}