using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _smoothingSpeed = 5;
    [SerializeField] private Vector3 _zOffset = new Vector3(0, 0, -10);
    [SerializeField] private float _fieldOfView = 15;
    [SerializeField] private float _minFieldOfView, _maxFieldOfView;

    [SerializeField] private Fighter[] _figthers;
    [SerializeField] public bool FollowFighters { get; private set; } = false;
    
    private Coroutine _coroutine;

    public void SetTargets(Enemy enemy, Player player)
    {
        _figthers[0] = player;
        _figthers[1] = enemy;
    }
    private void Awake()
    {
        _camera = GetComponent<Camera>();
        if (_figthers.Length != 2) { Debug.LogError("Set fighters"); }
    }

    private void Update()
    {
        if (!FollowFighters) { return; }
        if (_figthers.Length != 2) { return ; }

        float distance = Vector3.Distance(_figthers[0].transform.position, _figthers[1].transform.position);
        Vector3 newPosition = Vector3.Lerp(_figthers[0].transform.position, _figthers[1].transform.position, 0.5f) + _zOffset;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.fixedDeltaTime * _smoothingSpeed);
        _camera.fieldOfView = Mathf.Clamp(distance * _fieldOfView, _minFieldOfView, _maxFieldOfView);
    }

    public void SetFollow(bool state)
    {
        FollowFighters = state;
    }
    public void MoveCamera(Vector3 target, bool state)
    {
        if (_coroutine != null) { StopCoroutine(_coroutine); }
        _coroutine = StartCoroutine(MoveCameraTo(target, state));
    }
    public void MoveCamera(Vector3 target)
    {
        if (_coroutine != null) { StopCoroutine(_coroutine); }
        _coroutine = StartCoroutine(MoveCameraTo(target, FollowFighters));
    }
    private IEnumerator MoveCameraTo(Vector3 target, bool state)
    {
        while (Vector3.Distance(_camera.transform.position, (target + _zOffset)) > 0.1f)
        {
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, target + _zOffset, Time.fixedDeltaTime * _smoothingSpeed);
            yield return new WaitForEndOfFrame();
        }
        if (_coroutine != null)
        {
            FollowFighters = state;
            StopCoroutine(_coroutine);
        }
    }
}
