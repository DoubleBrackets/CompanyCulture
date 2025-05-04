using Notepad;
using UnityEngine;

public class SetNotepadActiveMono : MonoBehaviour
{
    [SerializeField]
    private bool _isActive;

    private void Start()
    {
        NotepadUI.Instance.SetNotepadActive(_isActive);
    }
}