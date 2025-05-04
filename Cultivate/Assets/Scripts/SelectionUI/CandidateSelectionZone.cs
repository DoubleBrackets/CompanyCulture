using Dev;
using Gameplay;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SelectionUI
{
    public class CandidateSelectionZone : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent<CandidateSelectionZone> _onCardSelected;

        [SerializeField]
        private UnityEvent<CandidateSelectionZone> _onCardDeselected;

        [SerializeField]
        private CandidateSO _candidate;

        public CandidateSO Candidate => _candidate;

        public UnityEvent<CandidateSelectionZone> OnCardSelectedEvent => _onCardSelected;
        public UnityEvent<CandidateSelectionZone> OnCardDeselectedEvent => _onCardDeselected;

        [ShowNonSerializedField]
        private bool _isSelected;

        private void OnDrawGizmos()
        {
            if (_candidate == null)
            {
                return;
            }
#if UNITY_EDITOR
            Handles.Label(transform.position, _candidate.name, EditorUtil.HighVisLabel);
#endif
            // Draw bounds
            Gizmos.color = Color.yellow;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            Vector2 size = GetComponent<RectTransform>().sizeDelta;
            Gizmos.DrawWireCube(Vector3.zero, size);
            Gizmos.matrix = Matrix4x4.identity;
        }

        public void SelectCard()
        {
            Debug.Log($"Card {name} seleced");
            _onCardSelected?.Invoke(this);
            _isSelected = true;
        }

        public void DeselectCard()
        {
            Debug.Log($"Card {name} deselected");
            _onCardDeselected?.Invoke(this);
            _isSelected = false;
        }

        public void ToggleSelection()
        {
            Debug.Log(_isSelected);
            if (_isSelected)
            {
                DeselectCard();
            }
            else
            {
                SelectCard();
            }
        }
    }
}