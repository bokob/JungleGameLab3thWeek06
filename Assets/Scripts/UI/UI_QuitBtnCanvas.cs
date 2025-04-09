using UnityEngine;
using UnityEngine.UI;

public class UI_QuitBtnCanvas : MonoBehaviour
{
    Canvas _quitBtnCanvas;
    Button _quitBtn;

    void Start()
    {
        _quitBtnCanvas = GetComponent<Canvas>();
        _quitBtn = GetComponentInChildren<Button>();
        _quitBtn.onClick.AddListener(() => { Application.Quit();});
    }
}