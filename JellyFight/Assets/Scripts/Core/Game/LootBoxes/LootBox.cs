using System.Collections;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    private Animator _animator;
    private readonly int[] _rewadrTable = { 100, 200, 300, 500, 1000 };

    private void Awake()
    {
        _animator = GetComponent<Animator>();    
    }

    /// <summary>
    /// Run using AnimationEvent
    /// </summary>
    public void Open()
    {
        
    }

    private int GetRewardValue()
    {
        int rewardIndex = Random.Range(0, _rewadrTable.Length);
        return _rewadrTable[rewardIndex];
    }
}
