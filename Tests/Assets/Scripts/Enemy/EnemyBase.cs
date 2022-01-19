using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyBase : MonoBehaviour,IDamageble
{
    public bool isAngry;
    public bool playerrange;
    public NavMeshAgent agent;
    public EnemyFollow enemyfollow;
    public RandomPoint randompoint;
    public TriggerObserver TriggerObserver;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private HealthBar _healthbar;
    private int _currentHealth;    

    
    protected virtual void Start()
    {
        TriggerObserver.TriggerEnter += TriggerEnter;
        TriggerObserver.TriggerExit += TriggerExit;

        _currentHealth = _maxHealth;
        enemyfollow.enabled = false;
        _healthbar.SetValue(_currentHealth, _maxHealth);
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

}
