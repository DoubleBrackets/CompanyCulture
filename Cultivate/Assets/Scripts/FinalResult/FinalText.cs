using System.Collections.Generic;
using Gameplay;
using Managers;
using UnityEngine;

namespace FinalResult
{
    public class FinalText : MonoBehaviour
    {
        [SerializeField]
        private GameStateSO _gameState;

        [SerializeField]
        private GameObject _mixedResult;

        [SerializeField]
        private GameObject _successResult;

        [SerializeField]
        private GameObject _failureResult;

        private void Start()
        {
            Dictionary<CandidateSO, GameStateSO.CandidateStatus> statuses = _gameState.CandidateStatuses;

            var anyFailed = false;
            var anyPassed = false;
            foreach (GameStateSO.CandidateStatus status in statuses.Values)
            {
                if (status.status == GameStateSO.CandidateStatusType.Failed)
                {
                    anyFailed = true;
                }
                else if (status.status == GameStateSO.CandidateStatusType.Persuaded)
                {
                    anyPassed = true;
                }
            }

            Debug.Log("Any Failed: " + anyFailed);
            Debug.Log("Any Passed: " + anyPassed);

            _mixedResult.SetActive(false);
            _successResult.SetActive(false);
            _failureResult.SetActive(false);

            if (anyFailed && anyPassed)
            {
                _mixedResult.SetActive(true);
            }
            else if (anyPassed)
            {
                _successResult.SetActive(true);
            }
            else if (anyFailed)
            {
                _failureResult.SetActive(true);
            }
            else
            {
                Debug.LogError("No candidates found in game state.");
            }
        }
    }
}