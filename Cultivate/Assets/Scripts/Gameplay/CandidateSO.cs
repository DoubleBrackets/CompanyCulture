using NaughtyAttributes;
using Persuasion;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "CandidateSO")]
    public class CandidateSO : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public PersuasionPortrait PersuasionPortrait { get; private set; }

        [field: SerializeField]
        public GameObject DetailedInformationPrefab { get; private set; }

        [field: SerializeField]
        public GameObject ExamineDesktopPrefab { get; private set; }

        [field: Header("Persuasion")]

        [field: SerializeField]
        [field: ResizableTextArea]
        public string CorrectPersuasionWords { get; private set; }

        [field: SerializeField]
        [field: ResizableTextArea]
        public string WrongPersuasionWords { get; private set; }

        [field: SerializeField]
        public int CorrectPersuasionsToPass { get; private set; }

        [field: SerializeField]
        public int WrongPersuasionsToFail { get; private set; }
    }
}