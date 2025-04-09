using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator _anim;
    Rigidbody2D _rb;
    Transform _visual;
    TrailRenderer _trailRenderer;

    [Header("공격")]
    [SerializeField] List<BoxCollider2D> _attackColliderList = new List<BoxCollider2D>();
    [SerializeField] float _attackCoolTime = 1f;
    [SerializeField] float _attackPower = 1000f;
    Coroutine _attackCoroutine;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _visual = transform.Find("Visual");
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
        _attackColliderList = GetComponentsInChildren<BoxCollider2D>().ToList();
    }

    public void TryAttack()
    {
        if (_attackCoroutine == null)
        {
            _anim.SetBool("IsAttack", true);
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {
        Vector2 dir = (GetMouseWorldPosition() - transform.position).normalized;
        Flip(dir.x);
        _rb.AddForce(dir * _attackPower);
        _trailRenderer.enabled = true;
        SetEnableAttackCollider(dir.x);
        yield return new WaitForSeconds(_attackCoolTime);
        _attackCoroutine = null;
        SetDisableAttackCollider();
        _anim.SetBool("IsAttack", false);
        _trailRenderer.Clear();
        _trailRenderer.enabled = false;
    }

    // 마우스 위치(월드 좌표) 반환
    Vector3 GetMouseWorldPosition()
    {
        // 마우스 위치(스크린 좌표)
        Vector3 mouseScreenPos = Input.mousePosition;

        // 마우스 위치의 z 좌표 = 인공위성의 z 스크린 좌표
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;

        // 마우스 위치를 월드 좌표로 변환
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    void Flip(float x)
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

    // 공격 콜라이더 활성화
    public void SetEnableAttackCollider(float x)
    {
        // 좌우
        if(x >= 0)
            _attackColliderList[0].enabled = true;
        else
            _attackColliderList[1].enabled = true;
    }

    // 모든 공격 콜라이더 비활성화
    public void SetDisableAttackCollider()
    {
        foreach (BoxCollider2D collider in _attackColliderList)
            collider.enabled = false;
    }
}