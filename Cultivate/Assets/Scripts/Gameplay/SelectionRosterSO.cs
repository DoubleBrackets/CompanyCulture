using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "SelectionRoster", menuName = "SelectionRosterSO", order = 1)]
    public class SelectionRosterSO : ScriptableObject
    {
        [field: SerializeField]
        public List<CandidateSO> Candidates { get; private set; }
    }
}