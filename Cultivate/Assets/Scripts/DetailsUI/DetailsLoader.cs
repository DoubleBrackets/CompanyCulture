using Gameplay;
using Managers;
using PopupUI;
using UnityEngine;

namespace DetailsUI
{
    public class DetailsLoader : MonoBehaviour
    {
        [SerializeField]
        private GameStateSO _gameStateSO;

        [SerializeField]
        private Transform _backgroundContainer;

        [SerializeField]
        private PopupWindow _defaultPopupWindow;

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
            CandidateSO examinedCandidate = _gameStateSO.ExaminedCandidate;
            if (examinedCandidate == null)
            {
                Debug.LogError("ExaminedCandidate is not set in GameStateSO.");
                return;
            }

            GameObject detailsPrefab = examinedCandidate.DetailedInformationPrefab;
            if (detailsPrefab == null)
            {
                Debug.LogError("DetailsPrefab is not set in ExaminedCandidate.");
                return;
            }

            _defaultPopupWindow.InstantiateContent(detailsPrefab);

            Instantiate(examinedCandidate.ExamineDesktopPrefab, _backgroundContainer);
        }
    }
}