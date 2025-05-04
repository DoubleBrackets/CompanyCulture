using System;
using System.Collections.Generic;
using Gameplay;
using Managers;
using UnityEngine;

namespace Persuasion
{
    public class PersuasionGame : MonoBehaviour
    {
        [SerializeField]
        private GameStateSO _gameStateSO;

        [SerializeField]
        private WordCloud _wordcloud;

        private int _correctsToWin;
        private int _wrongsToLose;

        private int _correctsSelected;
        private int _wrongsSelected;

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
        }

        private void OnDestroy()
        {
            _wordcloud.OnRightWordSelected.RemoveListener(HandleRightWordSelected);
            _wordcloud.OnWrongWordSelected.RemoveListener(HandleWrongWordSelected);
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 200, 20), $"Corrects: {_correctsSelected}/{_correctsToWin}");
            GUI.Label(new Rect(10, 30, 200, 20), $"Wrongs: {_wrongsSelected}/{_wrongsToLose}");
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
            _correctsSelected++;
            Debug.Log("Correct word selected");
        }

        private void HandleWrongWordSelected()
        {
            _wrongsSelected++;
            Debug.Log("Incorrect word selected");
        }
    }
}