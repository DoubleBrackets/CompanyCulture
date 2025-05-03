using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SelectionUI
{
    public class CandidateCard : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent<CandidateSO> _onCardSelected;

        [SerializeField]
        private Image _portraitImage;

        [SerializeField]
        private TMP_Text _nameText;

        public UnityEvent<CandidateSO> OnCardSelectedEvent => _onCardSelected;

        private CandidateSO _candidate;

        public void Initialize(CandidateSO candidate)
        {
            _portraitImage.sprite = candidate.Portrait;
            _nameText.text = candidate.Name;
            _candidate = candidate;
            name = $"{candidate.name} Card";
        }

        public void OnCardSelected()
        {
            Debug.Log($"Card {name} seleced");
            _onCardSelected?.Invoke(_candidate);
        }
    }
}