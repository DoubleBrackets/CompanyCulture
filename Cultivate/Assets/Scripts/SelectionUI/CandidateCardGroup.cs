using System.Collections.Generic;
using Gameplay;
using Managers;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace SelectionUI
{
    public class CandidateCardGroup : MonoBehaviour
    {
        [SerializeField]
        private List<CandidateSelectionZone> _candidates;

        [SerializeField]
        private GameStateSO _gameState;

        [SerializeField]
        [Scene]
        private string _examineSceneName;

        [SerializeField]
        [Scene]
        private string _persuasionSceneName;

        [SerializeField]
        private UnityEvent _onCandidateSelected;

        [SerializeField]
        private UnityEvent _onCandidateDeselected;

        private CandidateSelectionZone _selectedCandidate;

        private void Start()
        {
            foreach (CandidateSelectionZone candidate in _candidates)
            {
                candidate.OnCardSelectedEvent.AddListener(OnCardSelected);
                candidate.OnCardDeselectedEvent.AddListener(OnCardDeselected);

                CandidateSO candidateSO = candidate.Candidate;
                if (!_gameState.CandidateStatuses.ContainsKey(candidateSO))
                {
                    _gameState.SetStatus(candidateSO, GameStateSO.CandidateStatusType.Available);
                }

                candidate.SetStatus(_gameState.CandidateStatuses[candidateSO].status);

                Debug.Log("Adding candidate to game state: " + candidateSO.name);
            }
        }

        private void OnCardDeselected(CandidateSelectionZone candidate)
        {
            if (_selectedCandidate == candidate)
            {
                _selectedCandidate = null;
            }

            _onCandidateDeselected?.Invoke();
        }

        private void OnCardSelected(CandidateSelectionZone candidate)
        {
            if (candidate != _selectedCandidate && _selectedCandidate != null)
            {
                _selectedCandidate.DeselectCard();
            }

            _selectedCandidate = candidate;
            _onCandidateSelected?.Invoke();
        }

        public void ExamineSelectedCandidate()
        {
            if (_selectedCandidate == null)
            {
                Debug.LogWarning("No candidate selected");
                return;
            }

            Debug.Log($"Examining candidate: {_selectedCandidate.Candidate.name}");

            _gameState.ExaminedCandidate = _selectedCandidate.Candidate;

            SceneChanger.Instance.ChangeScene(_examineSceneName);
        }

        public void PersuadeSelectedCandidate()
        {
            if (_selectedCandidate == null)
            {
                Debug.LogWarning("No candidate selected");
                return;
            }

            Debug.Log($"Persuading candidate: {_selectedCandidate.Candidate.name}");

            _gameState.PersuadingCandidate = _selectedCandidate.Candidate;

            SceneChanger.Instance.ChangeScene(_persuasionSceneName);
        }
    }
}