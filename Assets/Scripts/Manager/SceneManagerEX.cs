using UnityEngine;
using UnityEngine.SceneManagement;
using static Define;

public class SceneManagerEX
{
    public void Init()
    {
        Debug.Log("SceneManagerEX 초기화");
    }

    // 씬 전환
    public void SwitchScene(SceneType sceneType)
    {
        string sceneName = sceneType.ToString();
        SceneManager.LoadScene(sceneName);
    }
}