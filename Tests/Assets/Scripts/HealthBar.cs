using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Health;

    public void SetValue(float currentHealth, float maxHealth)
    {
        Health.fillAmount = currentHealth / maxHealth;
    }
}
