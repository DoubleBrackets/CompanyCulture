using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Persuasion
{
    public class WordCloudWord : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _wordText;

        [SerializeField]
        private TextResizer _textResizer;

        [SerializeField]
        private float _driftMagnitude;

        [SerializeField]
        private float _driftSpeed;

        [SerializeField]
        private UnityEvent<WordCloudWord> _onWordSelected;

        [SerializeField]
        private UnityEvent _onInitialize;

        public UnityEvent<WordCloudWord> OnWordSelectedEvent => _onWordSelected;
        public string Word => _wordText.text;

        private bool _isSelected;

        private Vector2 _startPosition;
        private Vector2 _gradientStartPosition;

        private void Start()
        {
            _gradientStartPosition = new Vector2(
                Random.value,
                Random.value
            ) * 100;
        }

        private void Update()
        {
            var gradientNoiseOffset = new Vector2(
                Mathf.PerlinNoise(Time.time * _driftSpeed, _gradientStartPosition.x),
                Mathf.PerlinNoise(_gradientStartPosition.y, Time.time * _driftSpeed)
            );

            Vector2 offset = gradientNoiseOffset * _driftMagnitude;

            transform.position = _startPosition + offset;
        }

        public void Initialize(Vector2 pos, string word)
        {
            transform.position = pos;
            _startPosition = pos;
            _wordText.text = word;
            _isSelected = false;
            name = $"{word} Word";
            _textResizer.ResizeText();
            _onInitialize?.Invoke();
        }

        public void Select()
        {
            if (_isSelected)
            {
                Debug.LogWarning($"Word {name} is already selected.");
                return;
            }

            Debug.Log($"Word {name} selected");

            _isSelected = true;

            _onWordSelected?.Invoke(this);
        }
    }
}