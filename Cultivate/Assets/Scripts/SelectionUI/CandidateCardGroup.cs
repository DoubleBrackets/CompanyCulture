using System.Collections.Generic;
using Gameplay;
using Managers;
using NaughtyAttributes;
using UnityEngine;

namespace SelectionUI
{
    public class CandidateCardGroup : MonoBehaviour
    {
        [SerializeField]
        private CandidateCard _candidateCardPrefab;

        [SerializeField]
        private List<CandidateSO> _candidates;

        [SerializeField]
        private Transform _cardContainer;

        [SerializeField]
        private GameStateSO _gameState;

        [SerializeField]
        [Scene]
        private string _examineSceneName;

        private void Start()
        {
            foreach (CandidateSO candidate in _candidates)
            {
                CandidateCard card = Instantiate(_candidateCardPrefab, _cardContainer);
                card.Initialize(candidate);
                card.OnCardSelectedEvent.AddListener(OnCardSelected);
            }
        }

        private void OnCardSelected(CandidateSO candidate)
        {
            _gameState.ExaminedCandidate = candidate;
            SceneChanger.Instance.ChangeScene(_examineSceneName);
        }
    }
}