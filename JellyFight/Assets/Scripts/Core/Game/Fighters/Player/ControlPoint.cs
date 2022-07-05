using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ControlPoint : MonoBehaviour
{
    public BodyPartType BodyPart { get; private set; }

    private const float INPUT_OFFSET = 0.2f;

    private bool _isHitting = false;
    private bool _isDragged = false;

    private GameController _gameController;
    private Camera _camera;

    [SerializeField] private float _maxStrach = 1;
    [SerializeField] private Rig _rig;  
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _originalPosition;

    private void Start()
    {
        _camera = Camera.main;
        _gameController = FindObjectOfType<GameController>();
    }
    private void Update()
    {
        transform.LookAt(_camera.transform.position);
    }
    private void OnMouseDown()
    {
        _isDragged = true;
        _rig.weight = 1;
        _gameController.SetTimeScale(0.2f);
    }
    private void OnMouseDrag()
    {
        _target.position = GetInputPosition();
    }
    private void OnMouseUp()
    {
        _isDragged = false;
        _gameController.SetTimeScale(1f);

        Vector3 hitTarget = _originalPosition.position - _target.position;
        hitTarget += _originalPosition.position;

        _isHitting = true;
        StartCoroutine(Hit(hitTarget));
    }
    IEnumerator Hit(Vector3 targetPosition)
    {
        while(Vector3.Distance(_target.position, targetPosition) > 0.2f)
        {
            _target.position = Vector3.Lerp(_target.position, targetPosition, Time.fixedDeltaTime * 5f);
            yield return new WaitForEndOfFrame();
        }
        _rig.weight = 0;
        _isHitting = false;
    }
    private Vector3 GetInputPosition()
    {
        Vector3 nearPoint = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane));
        Vector3 farPoint = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.farClipPlane));
        Vector3 newPoint = Vector3.Lerp(nearPoint, farPoint, INPUT_OFFSET);
        return new Vector3(newPoint.x, newPoint.y, _target.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!_isHitting || _isDragged) { return; }
        if(collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().TakeHit();
            FindObjectOfType<Player>().MoveForvard();
            _isHitting = false;
        }
    }
}

public enum BodyPartType
{
    Head,
    LeftArm,
    RightArm,
    LeftLeg,
    RightLeg
}
