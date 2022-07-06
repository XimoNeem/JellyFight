using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image TimeScaledImage;
    [SerializeField] private RectTransform[] _mainSceneUIItems, _battleSceneUIItems;
    [SerializeField] private GameObject _winWindow;

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
