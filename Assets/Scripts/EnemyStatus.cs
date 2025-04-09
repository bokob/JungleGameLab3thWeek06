using UnityEngine;

// 적 스테이터스
public class EnemyStatus : MonoBehaviour, IStatus
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

    public float Damage => _damage;

    public float AttackCoolTime => _attackCoolTime;

    void Start()
    {
        _visual = transform.Find("Visual");
    }

    void Update()
    {
        
    }

    // 좌우 뒤집기
    public void Flip(float x)
    {
        if (x >= 0)
        {
            _visual.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (x < 0)
        {
            _visual.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
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

    public void Die()
    {
        _isDead = true;
        Debug.Log("적 사망");
    }
}