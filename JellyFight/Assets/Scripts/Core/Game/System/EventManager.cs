using System;

public static class EventManager
{
    public static Action OnFightStart, OnFightFinish, OnWin, OnLose;
    public static Action<CurrentSceneType> OnSceneChanged;
}