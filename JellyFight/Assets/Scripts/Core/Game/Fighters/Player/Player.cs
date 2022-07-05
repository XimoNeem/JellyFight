using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    public Transform EnemyTarget;
    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.fixedDeltaTime);
    }
    public void MoveForvard()
    {
        _targetPosition += Vector3.right * 1.5f;
    }
}
