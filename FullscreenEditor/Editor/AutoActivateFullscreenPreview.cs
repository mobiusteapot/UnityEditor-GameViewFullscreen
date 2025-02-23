using UnityEditor;

[InitializeOnLoad]
public class AutoActivateFullscreenPreview
{
    public const string IsFullscreenPreviewEnabledKey = "FullscreenGameViewEnabled";

    static AutoActivateFullscreenPreview()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if(EditorPrefs.GetBool(IsFullscreenPreviewEnabledKey, false))
        {
            if(state == PlayModeStateChange.EnteredPlayMode)
            {
                FullscreenGameView.SetFullscreen(true);
            }
            if(state == PlayModeStateChange.ExitingPlayMode)
            {
                FullscreenGameView.SetFullscreen(false);
            }
        }
    }
}
