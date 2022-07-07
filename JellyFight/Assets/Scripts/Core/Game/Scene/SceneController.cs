using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab, _playerPrefab;
    [SerializeField] private Transform _enemyPosition, _playerPosition;

    private Fighter _currentPlayer, _currentEnemy;

    private void OnEnable()
    {
        EventBus.OnFightStart += SpawnFighters;
        EventBus.OnFightFinish += DestroyFighters;
    }
    private void OnDisable()
    {
        EventBus.OnFightStart -= SpawnFighters;
        EventBus.OnFightFinish -= DestroyFighters;
    }
    public void SpawnFighters()
    {
        _currentEnemy = Instantiate(_enemyPrefab, _enemyPosition.position, _enemyPosition.rotation).GetComponent<Enemy>();
        _currentPlayer = Instantiate(_playerPrefab, _playerPosition.position, _playerPosition.rotation).GetComponent<Player>();

        FindObjectOfType<CameraController>().SetTargets(_currentPlayer, _currentEnemy);
    }
    public void DestroyFighters()
    {
        Destroy(_currentPlayer.gameObject);
        Destroy(_currentEnemy.gameObject);

        _currentEnemy = _currentPlayer = null;
    }
}
