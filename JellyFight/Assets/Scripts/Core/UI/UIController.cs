using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image TimeScaledImage;
    [SerializeField] private RectTransform[] _mainSceneUIItems, _battleSceneUIItems;
    [SerializeField] private GameObject _winWindow;
    

    private void OnEnable()
    {
        EventBus.OnWin += ActivateWinItems;
        EventBus.OnSceneChanged += ActivateUIItems;
    }
    private void OnDisable()
    {
        EventBus.OnWin -= ActivateWinItems;
        EventBus.OnSceneChanged -= ActivateUIItems;
    }
    public void ActivateUIItems(CurrentSceneType scene)
    {
        bool isMain = true;
        if (scene == CurrentSceneType.Battle) { isMain = false; }

        foreach (var item in _mainSceneUIItems)
        {
            item.gameObject.SetActive(isMain);
        }
        foreach (var item in _battleSceneUIItems)
        {
            item.gameObject.SetActive(!isMain);
        }
    }
    public void ActivateWinItems()
    {
        _winWindow.SetActive(true);
    }
}
