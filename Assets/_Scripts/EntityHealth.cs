using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class EntityHealth : MonoBehaviour
{
    //[SerializeField, Required] HealthUI _healthUI;
    [SerializeField] int _maxHealth;

    public int MaxHealth
    {
        get { return _maxHealth; }
    }

    public int CurrentHealth { get; private set; }


    //public event Action<int> OnHealthGained;
    public event Action<int> OnHealthLost;
    public event Action<int> OnHealthUpdate;

    Coroutine HealthRoutine { get; set; }
    Coroutine DamageRoutine { get; set; }
    Coroutine HealthSlider {  get; set; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void StartTakeDamage (int damage)
    {
        DamageRoutine = StartCoroutine(TakeDamage(damage));
        HealthSlider = StartCoroutine(UpdateHealthSlider());
    }
    IEnumerator TakeDamage(int damage)
    {
        OnHealthLost?.Invoke(damage);
        if (damage <= 0)
        {
            Debug.LogWarning("Damage must be greater than 0");
            yield break;
        }
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, _maxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
        yield return null;
    }
    IEnumerator UpdateHealthSlider ()
    {
        OnHealthUpdate?.Invoke(CurrentHealth);
        yield return null;
    }
    private int UpdateHealth(int previousHealth, int damage)
    {
        return previousHealth - damage;
    }
    private void Heal (int heal)
    {

    }
    
    private void Die()
    {
        Debug.LogWarning("Player just died !");
        Destroy(gameObject);
        Debug.Break();
    }
}
