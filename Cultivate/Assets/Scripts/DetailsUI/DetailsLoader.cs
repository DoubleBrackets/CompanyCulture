using Managers;
using UnityEngine;

namespace DetailsUI
{
    public class DetailsLoader : MonoBehaviour
    {
        [SerializeField]
        private GameStateSO _gameStateSO;

        [SerializeField]
        private Transform _detailsContainer;

        private void Awake()
        {
            if (_gameStateSO == null)
            {
                Debug.LogError("GameStateSO reference is not set in DetailsLoader.");
                return;
            }

            LoadDetails();
        }

        private void LoadDetails()
        {
            if (_gameStateSO.ExaminedCandidate == null)
            {
                Debug.LogError("ExaminedCandidate is not set in GameStateSO.");
                return;
            }

            GameObject detailsPrefab = _gameStateSO.ExaminedCandidate.DetailedInformationPrefab;
            if (detailsPrefab == null)
            {
                Debug.LogError("DetailsPrefab is not set in ExaminedCandidate.");
                return;
            }

            GameObject detailsInstance = Instantiate(detailsPrefab, _detailsContainer);
        }
    }
}