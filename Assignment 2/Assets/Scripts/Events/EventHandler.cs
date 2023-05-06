using System;
using System.Collections.Generic;
public static class EventHandler
{
    #region LOAD SCENE EVENTS
    // Scene Load Event - in the order they happen

    // Before Scene Unload Fade Out Event
    public static event Action BeforeSceneUnloadFadeOutEvent;
    public static void CallBeforeSceneUnloadFadeOutEvent()
    {
        if (BeforeSceneUnloadFadeOutEvent != null)
            BeforeSceneUnloadFadeOutEvent();
    }

    // Before Scene Unload Event
    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()
    {
        if (BeforeSceneUnloadEvent != null)
            BeforeSceneUnloadEvent();
    }

    // After Scene Loaded Event
    public static event Action AfterSceneLoadEvent;
    public static void CallAfterSceneLoadEvent()
    {
        if (AfterSceneLoadEvent != null)
            AfterSceneLoadEvent();
    }

    // After Scene Load Fade In Event
    public static event Action AfterSceneLoadFadeInEvent;
    public static void CallAfterSceneLoadFadeInEvent()
    {
        if (AfterSceneLoadFadeInEvent != null)
            AfterSceneLoadFadeInEvent();
    }
    #endregion
}
