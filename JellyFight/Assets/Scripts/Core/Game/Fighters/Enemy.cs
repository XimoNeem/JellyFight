using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter
{

    private Rigidbody _rigidbody;
    private Player _player;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = FindObjectOfType<Player>();
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.EnemyTarget.position, Time.fixedDeltaTime * 0.5f);
    }

    public void TakeHit()
    {
        _rigidbody.AddForce(Vector3.right * 250);
    }
}
