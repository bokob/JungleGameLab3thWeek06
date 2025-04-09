
// 플레이어 및 몬스터의 상태 인터페이스
public interface IStatus
{
    public bool IsDead { get; }             // 죽음 여부
    public float HP { get;}                 // 체력
    public float MaxHP { get; }             // 최대 체력
    public float Damage { get; }            // 데미지
    public float AttackCoolTime { get; }    // 공격 쿨타임

    public void Flip(float x);               // 좌우 뒤집기
    public void TakeDamage(float damage);   // 데미지 받기
    public void Die();                      // 죽음 처리
}