using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public UnityEvent OnFightStart, OnFightFinish, OnWin, OnLose;

    private void Awake()
    {
        Instance = this;
    }
}