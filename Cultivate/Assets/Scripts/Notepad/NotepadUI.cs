using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace Notepad
{
    public class NotepadUI : MonoBehaviour
    {
        [SerializeField]
        private Transform _closedPosition;

        [SerializeField]
        private Transform _openPosition;

        [SerializeField]
        private Transform _notepadTransform;

        [SerializeField]
        private float _openTime;

        [SerializeField]
        private Ease _openEase;

        [SerializeField]
        private Ease _closeEase;

        private Tween _moveTween;
        private Tween _rotateTween;

        private bool _isOpen;

        private void Awake()
        {
            _notepadTransform.position = _closedPosition.position;
        }

        public void OpenNotepad()
        {
            if (_isOpen)
            {
                return;
            }

            _isOpen = true;
            CompleteTween();

            _moveTween = _notepadTransform
                .DOMove(_openPosition.position, _openTime)
                .SetEase(_openEase);

            _rotateTween = _notepadTransform
                .DORotate(_openPosition.rotation.eulerAngles, _openTime)
                .SetEase(_openEase);
        }

        public void CloseNotepad()
        {
            if (!_isOpen)
            {
                return;
            }

            _isOpen = false;
            CompleteTween();

            _moveTween = _notepadTransform
                .DOMove(_closedPosition.position, _openTime)
                .SetEase(_closeEase);

            _rotateTween = _notepadTransform
                .DORotate(_closedPosition.rotation.eulerAngles, _openTime)
                .SetEase(_openEase);
        }

        private void CompleteTween()
        {
            if (_moveTween.IsActive())
            {
                _moveTween.Kill();
            }

            if (_rotateTween.IsActive())
            {
                _rotateTween.Kill();
            }
        }

        [Button("Open Notepad")]
        private void OpenNotepadButton()
        {
            MatchPositionAndRotation(_notepadTransform, _openPosition);
        }

        [Button("Close Notepad")]
        private void CloseNotepadButton()
        {
            MatchPositionAndRotation(_notepadTransform, _closedPosition);
        }

        private void MatchPositionAndRotation(Transform target, Transform source)
        {
            target.position = source.position;
            target.rotation = source.rotation;
        }
    }
}