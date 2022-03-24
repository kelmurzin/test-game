using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyBase
{        
    [SerializeField] private Transform firepoint;
    [SerializeField] private float range = 1f;
    [SerializeField] private int _damage = 20;
    
    public override void StartAttack()
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
                playerhealth.TakeDamage(_damage);
                            
            ParticleFX.Instance.EnemyRangeExplosionFX(hit.point);
        }
    }
    
    protected override bool CanAttack() =>
     isAngry && !_isAttacking && CooldownIsUp();
}
