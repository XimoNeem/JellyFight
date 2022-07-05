using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseTrigger : MonoBehaviour
{
    [SerializeField] TargetType _targetType;
    private GameController _gameController;
    
    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (!collision.GetComponent<Fighter>()) { return; }

        Fighter fighter = collision.GetComponent<Fighter>();
        if (fighter is Player)
        {
            if(_targetType == TargetType.Player) { _gameController.FinishFight(false); }
        }
        else if (fighter is Enemy)
        {
            if(_targetType == TargetType.Enemy) { _gameController.FinishFight(true); }
        }
    }
}

public enum TargetType 
{
    Player,
    Enemy
}