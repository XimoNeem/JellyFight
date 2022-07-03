using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab, _playerPrefab;
    [SerializeField] private Transform _enemyPosition, _playerPosition;

    public void SpawnFighters()
    {
        Enemy enemy = Instantiate(_enemyPrefab, _enemyPosition.position, _enemyPosition.rotation).GetComponent<Enemy>();
        Player player = Instantiate(_playerPrefab, _playerPosition.position, _playerPosition.rotation).GetComponent<Player>();

        FindObjectOfType<CameraController>().SetTargets(enemy, player);
    }
}
