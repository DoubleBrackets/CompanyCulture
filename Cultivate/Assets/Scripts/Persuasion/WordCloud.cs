using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Persuasion
{
    public class WordCloud : MonoBehaviour
    {
        [SerializeField]
        private WordCloudWord _correctWordPrefab;

        [SerializeField]
        private WordCloudWord _incorrectWordPrefab;

        [SerializeField]
        private UnityEvent _onRightWordSelected;

        [SerializeField]
        private UnityEvent _onWrongWordSelected;

        [SerializeField]
        private Vector2 _wordSpawnLowerBound;

        [SerializeField]
        private Vector2 _wordSpawnUpperBound;

        [SerializeField]
        private Transform _wordSpawnTransform;

        public UnityEvent OnRightWordSelected => _onRightWordSelected;
        public UnityEvent OnWrongWordSelected => _onWrongWordSelected;

        private readonly List<WordCloudWord> _correctWordClouds = new();
        private readonly List<WordCloudWord> _incorrectWordClouds = new();

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_wordSpawnLowerBound, new Vector2(_wordSpawnLowerBound.x, _wordSpawnUpperBound.y));
            Gizmos.DrawLine(_wordSpawnLowerBound, new Vector2(_wordSpawnUpperBound.x, _wordSpawnLowerBound.y));
            Gizmos.DrawLine(_wordSpawnUpperBound, new Vector2(_wordSpawnUpperBound.x, _wordSpawnLowerBound.y));
            Gizmos.DrawLine(_wordSpawnUpperBound, new Vector2(_wordSpawnLowerBound.x, _wordSpawnUpperBound.y));
        }

        public void InitializeWordCloud(List<string> correctWords, List<string> incorrectWords)
        {
            foreach (string word in correctWords)
            {
                WordCloudWord wordCloudWord = Instantiate(_correctWordPrefab, _wordSpawnTransform);
                wordCloudWord.Initialize(GetRandomPosition(), word);
                wordCloudWord.OnWordSelectedEvent.AddListener(CorrectWordSelected);
                _correctWordClouds.Add(wordCloudWord);
            }

            foreach (string word in incorrectWords)
            {
                WordCloudWord wordCloudWord = Instantiate(_incorrectWordPrefab, _wordSpawnTransform);
                wordCloudWord.Initialize(GetRandomPosition(), word);
                wordCloudWord.OnWordSelectedEvent.AddListener(IncorrectWordSelected);
                _incorrectWordClouds.Add(wordCloudWord);
            }
        }

        private Vector2 GetRandomPosition()
        {
            float x = Random.Range(_wordSpawnLowerBound.x, _wordSpawnUpperBound.x);
            float y = Random.Range(_wordSpawnLowerBound.y, _wordSpawnUpperBound.y);
            return new Vector2(x, y);
        }

        private void CorrectWordSelected(WordCloudWord word)
        {
            Debug.Log($"Correct word {word.name} selected");
            OnRightWordSelected?.Invoke();

            word.OnWordSelectedEvent.RemoveListener(CorrectWordSelected);
            _correctWordClouds.Remove(word);
        }

        private void IncorrectWordSelected(WordCloudWord word)
        {
            Debug.Log($"Incorrect word {word.name} selected");
            OnWrongWordSelected?.Invoke();

            word.OnWordSelectedEvent.RemoveListener(IncorrectWordSelected);
            _incorrectWordClouds.Remove(word);
        }
    }
}