using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Insnance;
    public UnityEvent OnFightStart, OnFightFinish;

    private void Awake()
    {
        Insnance = this;
    }
}