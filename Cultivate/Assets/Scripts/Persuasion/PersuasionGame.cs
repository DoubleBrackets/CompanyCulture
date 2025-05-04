using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Gameplay;
using Managers;
using NaughtyAttributes;
using UnityEngine;

namespace Persuasion
{
    public class PersuasionGame : MonoBehaviour
    {
        [SerializeField]
        private GameStateSO _gameStateSO;

        [SerializeField]
        private WordCloud _wordcloud;

        [SerializeField]
        private Transform _persuasionPortraitContainer;

        [SerializeField]
        private AnimationCurve _zoomCurve;

        [Header("Scenes")]

        [SerializeField]
        [Scene]
        private string _progressResultScene;

        [SerializeField]
        [Scene]
        private string _finalEndingScene;

        private PersuasionPortrait _persuasionPortrait;

        private int _correctsToWin;
        private int _wrongsToLose;

        private int _correctsSelected;
        private int _wrongsSelected;

        private bool _finishedPersuasionGame;

        private void Awake()
        {
            CandidateSO candidate = _gameStateSO.PersuadingCandidate;

            _correctsToWin = candidate.CorrectPersuasionsToPass;
            _wrongsToLose = candidate.WrongPersuasionsToFail;

            _wordcloud.OnRightWordSelected.AddListener(HandleRightWordSelected);
            _wordcloud.OnWrongWordSelected.AddListener(HandleWrongWordSelected);

            _wordcloud.InitializeWordCloud(
                SplitByNewline(candidate.CorrectPersuasionWords),
                SplitByNewline(candidate.WrongPersuasionWords));

            _persuasionPortrait = Instantiate(candidate.PersuasionPortrait, _persuasionPortraitContainer);

            _persuasionPortrait.SetZoom(0);
        }

        private void OnDestroy()
        {
            _wordcloud.OnRightWordSelected.RemoveListener(HandleRightWordSelected);
            _wordcloud.OnWrongWordSelected.RemoveListener(HandleWrongWordSelected);
        }

        private void OnGUI()
        {
            if (Application.isEditor)
            {
                GUI.Label(new Rect(10, 10, 200, 20), $"Corrects: {_correctsSelected}/{_correctsToWin}");
                GUI.Label(new Rect(10, 30, 200, 20), $"Wrongs: {_wrongsSelected}/{_wrongsToLose}");
            }
        }

        private List<string> SplitByNewline(string csv)
        {
            var list = new List<string>();
            string[] items = csv.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in items)
            {
                list.Add(item.Trim());
            }

            return list;
        }

        private void HandleRightWordSelected()
        {
            if (_finishedPersuasionGame)
            {
                return;
            }

            _correctsSelected++;
            float t = _correctsSelected / (float)_correctsToWin;

            _persuasionPortrait.SetZoom(_zoomCurve.Evaluate(t));
            Debug.Log("Correct word selected");

            if (_correctsSelected >= _correctsToWin)
            {
                Debug.Log("All correct words selected");
                _gameStateSO.SetStatus(
                    _gameStateSO.PersuadingCandidate,
                    GameStateSO.CandidateStatusType.Persuaded);
                PassPersuasionGame().Forget();
            }
        }

        private void HandleWrongWordSelected()
        {
            if (_finishedPersuasionGame)
            {
                return;
            }

            _wrongsSelected++;
            Debug.Log("Incorrect word selected");

            if (_wrongsSelected >= _wrongsToLose)
            {
                Debug.Log("All wrong words selected");
                _gameStateSO.SetStatus(
                    _gameStateSO.PersuadingCandidate,
                    GameStateSO.CandidateStatusType.Failed);
                PassPersuasionGame().Forget();
            }
        }

        private async UniTaskVoid PassPersuasionGame()
        {
            _finishedPersuasionGame = true;
            await UniTask.Delay(TimeSpan.FromSeconds(1));

            GameStateSO.CandidateStatus availableCandidates =
                _gameStateSO.CandidateStatuses.Values.FirstOrDefault(
                    a => a.status == GameStateSO.CandidateStatusType.Available);

            if (availableCandidates != null)
            {
                SceneChanger.Instance.ChangeScene(_progressResultScene);
            }
            else
            {
                SceneChanger.Instance.ChangeScene(_finalEndingScene);
            }
        }
    }
}