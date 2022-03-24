using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public abstract class EnemyBase : MonoBehaviour,IDamageble,IAttack
{
    public bool isAngry;
    public bool playerrange;
    public NavMeshAgent agent;
    public EnemyFollow enemyfollow;
    public RandomPoint randompoint;
    public TriggerObserver TriggerObserver;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private HealthBar _healthbar;
    [SerializeField] protected float AttackCooldown = 3.0f;
    private int _currentHealth;
    protected float _attackCooldown;
    protected bool _isAttacking;

    protected  void Start()
    {
        TriggerObserver.TriggerEnter += TriggerEnter;
        TriggerObserver.TriggerExit += TriggerExit;

        _currentHealth = _maxHealth;
        enemyfollow.enabled = false;
        _healthbar.SetValue(_currentHealth, _maxHealth);
    }

    protected void Update()
    {
        UpdateCooldown();

        if (CanAttack())
            StartAttack();
    }

    protected void OnAttackEnded()
    {
        _attackCooldown = AttackCooldown;
        _isAttacking = false;
    }

    protected bool CooldownIsUp() =>
      _attackCooldown <= 0f;

    protected void UpdateCooldown()
    {
        if (!CooldownIsUp())
            _attackCooldown -= Time.deltaTime;
    }

    private void TriggerEnter(Collider obj)
    {
        isAngry = true;
        enemyfollow.enabled = true;
        randompoint.enabled = false;
    }

    private void TriggerExit(Collider obj)
    {
        isAngry = false;
        enemyfollow.enabled = false;
        randompoint.enabled = true;
    }
   

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthbar.SetValue(_currentHealth, _maxHealth);
        if (_currentHealth <=0)
        {
            gameObject.SetActive(false);
           
        }
    }
    private void OnEnable()
    {
        TriggerObserver.TriggerExit += TriggerExit;
        TriggerObserver.TriggerEnter += TriggerEnter;
        
        _currentHealth = _maxHealth;
        _healthbar.SetValue(_currentHealth, _maxHealth);
        
        
    }
    private void OnDisable()
    {
        
        TriggerObserver.TriggerEnter -= TriggerEnter;
        TriggerObserver.TriggerExit -= TriggerExit;
        
    }
    protected virtual bool CanAttack() =>
     !_isAttacking && CooldownIsUp();

    public virtual void StartAttack()
    {
        
    }
}
