using UnityEngine;

public class InGameScene : MonoBehaviour
{
    void Awake()
    {
        Init();
    }

    public void Init()
    {
        Manager.UI.Init();
        Manager.Sound.Init();
        Manager.Data.Init();
    }
}
