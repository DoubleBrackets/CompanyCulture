using System.Collections.Generic;
using Gameplay;
using Managers;
using UnityEditor;
using UnityEngine;

namespace Dev.Editor
{
    [CustomEditor(typeof(GameStateSO))]
    public class GameStateSODrawer : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var gameState = (GameStateSO)target;

            foreach (KeyValuePair<CandidateSO, GameStateSO.CandidateStatus> pair in gameState.CandidateStatuses)
            {
                EditorGUILayout.LabelField(
                    $"Candidate: {pair.Key.name}, Status: {pair.Value.status}");
            }

            if (GUILayout.Button("Clear Candidate Status"))
            {
                gameState.CandidateStatuses.Clear();
                EditorUtility.SetDirty(gameState);
            }

            if (GUILayout.Button("Set All To Done"))
            {
                foreach (KeyValuePair<CandidateSO, GameStateSO.CandidateStatus> pair in gameState.CandidateStatuses)
                {
                    pair.Value.status = GameStateSO.CandidateStatusType.Persuaded;
                }

                EditorUtility.SetDirty(gameState);
            }

            if (GUILayout.Button("Set All To Failed"))
            {
                foreach (KeyValuePair<CandidateSO, GameStateSO.CandidateStatus> pair in gameState.CandidateStatuses)
                {
                    pair.Value.status = GameStateSO.CandidateStatusType.Failed;
                }

                EditorUtility.SetDirty(gameState);
            }

            if (GUILayout.Button("Set All To Random"))
            {
                foreach (KeyValuePair<CandidateSO, GameStateSO.CandidateStatus> pair in gameState.CandidateStatuses)
                {
                    pair.Value.status = Random.value > 0.5f
                        ? GameStateSO.CandidateStatusType.Persuaded
                        : GameStateSO.CandidateStatusType.Failed;
                }

                EditorUtility.SetDirty(gameState);
            }
        }
    }
}