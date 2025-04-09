using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager _instance;
    public static Manager Instance => _instance;

    static UIManager _ui = new UIManager();
    static SoundManager _sound = new SoundManager();
    static DataManager _data = new DataManager();
    static SceneManagerEX _scene = new SceneManagerEX();
    static ResourceManager _resource = new ResourceManager();

    public static UIManager UI => _ui;
    public static ResourceManager Resource => _resource;
    public static SoundManager Sound => _sound;
    public static DataManager Data => _data;
    public static SceneManagerEX Scene => _scene;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        if (_instance == null)
        {
            Debug.Log("Manager 초기화");
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}