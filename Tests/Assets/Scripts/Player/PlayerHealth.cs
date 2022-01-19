using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerHealth : MonoBehaviour,IDamageble
{
    [SerializeField] private HealthBar _healthbar;
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;

    public  event Action OnDie;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthbar.SetValue(_currentHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthbar.SetValue(_currentHealth, _maxHealth);
        
        if (_currentHealth <= 0)
        {
            OnDie?.Invoke();
            
        }
    }

   
}
