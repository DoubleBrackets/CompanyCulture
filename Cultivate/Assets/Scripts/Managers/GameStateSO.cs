using System;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "GameStateSO", menuName = "GameStateSO")]
    public class GameStateSO : ScriptableObject
    {
        public enum CandidateStatusType
        {
            Available,
            Persuaded,
            Failed
        }

        [Serializable]
        public class CandidateStatus
        {
            public CandidateSO candidate;
            public CandidateStatusType status;
        }

        [field: SerializeField]
        public CandidateSO ExaminedCandidate { get; set; }

        [field: SerializeField]
        public CandidateSO PersuadingCandidate { get; set; }

        public Dictionary<CandidateSO, CandidateStatus> CandidateStatuses { get; set; } = new();

        public void SetStatus(CandidateSO candidate, CandidateStatusType status)
        {
            if (CandidateStatuses.ContainsKey(candidate))
            {
                CandidateStatuses[candidate].status = status;
            }
            else
            {
                CandidateStatuses.Add(candidate, new CandidateStatus
                {
                    candidate = candidate,
                    status = status
                });
            }
        }
    }
}