using UnityEngine;

// 플레이어 스테이터스
public class PlayerStatus : MonoBehaviour, IStatus
{
    [SerializeField] bool _isDead;
    [SerializeField] float _hp;
    [SerializeField] float _maxHp;
    [SerializeField] float _damage;
    [SerializeField] float _attackCoolTime;
    [SerializeField] float _attackPower;
    Transform _visual;

    public bool IsDead => _isDead;
    public float HP => _hp;
    public float MaxHP => _maxHp;
    public float Damage { get => _damage; set { _damage = value; } }
    public float AttackCoolTime => _attackCoolTime;

    void Start()
    {
        _visual = transform.Find("Visual");
    }

    // 좌우 뒤집기
    public void Flip(float x)
    {
        _visual.transform.rotation = (x >= 0) ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
    }

    // 데미지 받기
    public void TakeDamage(float damage)
    {
        if (!_isDead)
        {
            _hp = Mathf.Clamp(_hp - damage, 0, _maxHp);
            if (_hp <= 0)
            {
                Die();
            }
        }
    }

    // 죽음 처리
    public void Die()
    {
        _isDead = true;
        Debug.Log("플레이어 사망");
    }
}