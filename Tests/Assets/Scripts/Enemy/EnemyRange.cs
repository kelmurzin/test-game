using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyBase
{
    

    [SerializeField] private float AttackCooldown = 3.0f;
    [SerializeField] private Transform firepoint;
    [SerializeField] private float range = 1f;
    [SerializeField] private int _damage = 20;

    private float _attackCooldown;
    private bool _isAttacking;


    private void  Update()
    {        

        UpdateCooldown();

        if (CanAttack())
            StartAttack();
        
    }

    private void StartAttack()
    {
        Shoot();
        OnAttackEnded();
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(firepoint.transform.position, firepoint.transform.forward, out hit, range))
        {
            PlayerHealth playerhealth = hit.transform.GetComponent<PlayerHealth>();
            if (playerhealth!=null )
            {
                playerhealth.TakeDamage(_damage);
                
            }
            ParticleFX.Instance.EnemyRangeExplosionFX(hit.point);
        }

    }

    private void OnAttackEnded()
    {
        _attackCooldown = AttackCooldown;
        _isAttacking = false;
    }

    private bool CooldownIsUp() =>
      _attackCooldown <= 0f;

    private void UpdateCooldown()
    {
        if (!CooldownIsUp())
            _attackCooldown -= Time.deltaTime;
    }

    private bool CanAttack() =>
     isAngry && !_isAttacking && CooldownIsUp();


}
