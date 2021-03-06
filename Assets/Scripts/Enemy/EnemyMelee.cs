using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyMelee : EnemyBase
{    
    [SerializeField] private float Cleavage = 0.5f;
    [SerializeField] private float EffectiveDistance = 0.5f;
    [SerializeField] private int _damage = 10;
   
    private Collider[] _hits = new Collider[1];
    private int _layerMask;
    
    private void Awake() =>
      _layerMask = 1 << LayerMask.NameToLayer("Player");

    public override void StartAttack()
    {    
        if (Hit(out Collider hit))
        {
            PlayerHealth playerhealth = hit.transform.GetComponent<PlayerHealth>();
            if (playerhealth != null)
                playerhealth.TakeDamage(_damage);

            OnAttackEnded();
        }
    }
    
    private bool Hit(out Collider hit)
    {        
        int hitAmount = Physics.OverlapSphereNonAlloc(StartPoint(), Cleavage, _hits, _layerMask);
        hit = _hits.FirstOrDefault();
        return hitAmount > 0;
    }
    
    private Vector3 StartPoint()
    {
        return new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
               transform.forward * EffectiveDistance;
    }
}

