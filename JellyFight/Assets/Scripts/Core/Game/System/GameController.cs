using UnityEngine;

public class GameController : MonoBehaviour
{
    private const float TIME_SMOOTH = 1.5f;

    public CurrentSceneType CurrentScene { get; private set; } = CurrentSceneType.Main;
    [SerializeField] private Transform _mainScene, _battleScene;

    private CameraController _cameraController;
    private UIController _uiController;

    private float _targetTimeScale = 1;

    private void Start()
    {
        _cameraController = FindObjectOfType<CameraController>();
        _uiController = FindObjectOfType<UIController>();
    }
    private void Update()
    {
        CalculateTimeScale();
    }
    private void CalculateTimeScale()
    {
        Time.timeScale = Mathf.Lerp(Time.timeScale, _targetTimeScale, Time.fixedDeltaTime * TIME_SMOOTH);
        Color newColor = Color.white;
        newColor.a = Mathf.Lerp(0.5f, 0, Time.timeScale);
        _uiController.TimeScaledImage.color = newColor;
    }
    public void SetTimeScale(float scale)
    {
        _targetTimeScale = scale;
    }
    public void StartFight()
    {
        if(_cameraController != null)
        {
            _cameraController.MoveCamera(_battleScene.position, true);
        }

        SetCurrentScene(CurrentSceneType.Battle);
        EventBus.OnFightStart?.Invoke();
        EventBus.OnSceneChanged?.Invoke(CurrentScene);
    }
    public void FinishFight(bool win)
    {
        if (_cameraController != null)
        {
            _cameraController.SetFollow(false);
            _cameraController.MoveCamera(_mainScene.position);
        }

        SetCurrentScene(CurrentSceneType.Main);
        EventBus.OnFightFinish?.Invoke();
        EventBus.OnSceneChanged?.Invoke(CurrentScene);

        if (win) { EventBus.OnWin?.Invoke(); }
        else { EventBus.OnLose?.Invoke(); }
    }
    public void SetCurrentScene(CurrentSceneType scene)
    {
        CurrentScene = scene;
    }
}

public enum CurrentSceneType
{
    Main,
    Battle
}