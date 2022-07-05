using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab, _playerPrefab;
    [SerializeField] private Transform _enemyPosition, _playerPosition;

    private Fighter _currentPlayer, _currentEnemy;

    public void SpawnFighters()
    {
        _currentEnemy = Instantiate(_enemyPrefab, _enemyPosition.position, _enemyPosition.rotation).GetComponent<Enemy>();
        _currentPlayer = Instantiate(_playerPrefab, _playerPosition.position, _playerPosition.rotation).GetComponent<Player>();

        FindObjectOfType<CameraController>().SetTargets(_currentEnemy, _currentPlayer);
    }
    public void DestroyFighters()
    {
        _currentEnemy = _currentPlayer = null;

        Destroy(_currentPlayer.gameObject);
        Destroy(_currentEnemy.gameObject);
    }
}
