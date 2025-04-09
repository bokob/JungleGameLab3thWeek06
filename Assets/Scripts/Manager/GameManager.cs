using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;

    [Header("소환")]
    [SerializeField] GameObject _earthPrefab;
    [SerializeField] Transform _earth;
    public Transform Earth => _earth;
    [SerializeField] GameObject _meteorPrefab;
    List<Transform> _meteorList = new List<Transform>();

    void Awake()
    {
        if (_instance == null)
        {
            Debug.Log("GameManager 초기화");
            _instance = this;
        }
        SpawnEarth();
        SpawnMeteor();
    }

    // 지구 소환
    public void SpawnEarth()
    {
        _earth = Instantiate(_earthPrefab, new Vector3(0, 0, 0), Quaternion.identity).transform;
    }

    // 운석 소환
    public void SpawnMeteor()
    {
        GameObject _meteor = Instantiate(_meteorPrefab, new Vector3(Random.Range(-10f, 10f), 10f, 0), Quaternion.identity);
        _meteorList.Add(_meteor.transform);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}