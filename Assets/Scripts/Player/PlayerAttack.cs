using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _attackTime;
    public float AttackTime { get { return _attackTime; } }
    public float Damage { get { return _damage; } }
    public float Distance { get { return _maxDistance; } }
    private bool _onCooldown = false;
    private Ray r;

    private void Update()
    {
        if (Input.GetMouseButton(0)) Attack();
    }

    public void Attack()
    {
        if (_onCooldown) return;
        _onCooldown = true;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxDistance) && hit.transform.TryGetComponent(out AIHealth enemy)) enemy.TakeDamage(_damage);
        
        StartCoroutine(CoolingDown());
    }

    private IEnumerator CoolingDown()
    {
        yield return new WaitForSeconds(_attackTime);
        _onCooldown = false;
    }

    public void UpCoolingDown() =>
        _attackTime -= _attackTime / 100 * 10;
    public void UpDamage() =>
        _damage *= 2;
    public void UpDistance() =>
        _maxDistance *= 1.3f;
}
