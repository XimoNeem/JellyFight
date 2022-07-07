using System;

public static class EventBus
{
    public static Action OnFightStart, OnFightFinish, OnWin, OnLose;
    public static Action<CurrentSceneType> OnSceneChanged;
}