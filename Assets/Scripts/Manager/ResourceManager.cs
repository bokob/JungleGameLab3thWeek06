using UnityEngine;

public class ResourceManager
{
    // Resources 폴더에 있는 리소스 로드
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    // Resources 폴더에 있는 프리팹을 로드하고 인스턴스화
    public GameObject Load(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.LogError($"로드 실패: {path}");
            return null;
        }
        return Object.Instantiate(prefab, parent);
    }
}