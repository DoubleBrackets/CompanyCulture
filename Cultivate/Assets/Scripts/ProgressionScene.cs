using Cysharp.Threading.Tasks;
using Managers;
using UnityEngine;

public class ProgressionScene : MonoBehaviour
{
    [SerializeField]
    private GameObject _successLine;

    [SerializeField]
    private GameObject _failureLine;

    [SerializeField]
    private GameObject _neutralLine;

    [SerializeField]
    private Transform _container;

    [SerializeField]
    private GameStateSO _gameState;

    [SerializeField]
    private float _delay;

    [SerializeField]
    private GameObject _nextButton;

    private void Start()
    {
        ProgressionCutscene().Forget();
    }

    private async UniTaskVoid ProgressionCutscene()
    {
        _nextButton.SetActive(false);

        foreach (GameStateSO.CandidateStatus status in _gameState.CandidateStatuses.Values)
        {
            await UniTask.Delay((int)(_delay * 1000));
            if (status.status == GameStateSO.CandidateStatusType.Persuaded)
            {
                GameObject successLine = Instantiate(_successLine, _container);
            }
            else if (status.status == GameStateSO.CandidateStatusType.Failed)
            {
                GameObject failureLine = Instantiate(_failureLine, _container);
            }
            else
            {
                GameObject neutralLine = Instantiate(_neutralLine, _container);
            }
        }

        await UniTask.Delay((int)(_delay * 2000));

        _nextButton.SetActive(true);
    }
}