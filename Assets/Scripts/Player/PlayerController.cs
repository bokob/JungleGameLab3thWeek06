using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerAttack _playerAttack;

    void Start()
    {
        _playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _playerAttack.TryAttack();
        }
    }
}