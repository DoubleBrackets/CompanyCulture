using Managers;
using UnityEngine;

public class CursorSetMono : MonoBehaviour
{
    [SerializeField]
    private CursorManager.CursorTypes _cursorType;

    public void SetCursor()
    {
        CursorManager.Instance.SetCursor(_cursorType);
    }

    public void UnsetCursor()
    {
        CursorManager.Instance.SetCursor(CursorManager.CursorTypes.Default);
    }
}