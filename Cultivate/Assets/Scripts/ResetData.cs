using Managers;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    [SerializeField]
    private GameStateSO _gameState;

    private void Start()
    {
        _gameState.CandidateStatuses.Clear();
    }
}