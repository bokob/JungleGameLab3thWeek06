using UnityEngine;
using UnityEngine.UI;
using static Define;

public class UI_StartBtnCanvas : MonoBehaviour
{
    Canvas _startBtnCanvas;
    Button _startBtn;

    void Start()
    {
        _startBtnCanvas = GetComponent<Canvas>();
        _startBtn = GetComponentInChildren<Button>();
        _startBtn.onClick.AddListener(() => {
            Manager.Scene.SwitchScene(SceneType.InGameScene);
        });
    }
}