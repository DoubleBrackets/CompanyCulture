using UnityEngine;

namespace Dev
{
    public class EditorUtil
    {
#if UNITY_EDITOR
        private static GUIStyle _highVisLabel;

        public static GUIStyle HighVisLabel
        {
            get
            {
                if (_highVisLabel == null)
                {
                    _highVisLabel = new GUIStyle(GUI.skin.label)
                    {
                        normal = { textColor = Color.yellow },
                        fontSize = 25
                    };
                }

                return _highVisLabel;
            }
        }
#endif
    }
}