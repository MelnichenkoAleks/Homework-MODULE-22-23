using UnityEngine;

public class Health
{
    private float _maxHealth;
    private float _currentHealth;

    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public float Current => _currentHealth;
    public float Max => _maxHealth;
    public bool IsAlive => _currentHealth > 0f;

    public void TakeDamage(float damage)
    {
        if (!IsAlive)
            return;

        _currentHealth -= damage;
        _currentHealth = Mathf.Max(_currentHealth, 0f);

        Debug.Log($"Получено {damage} урона. Текущее здоровье: {_currentHealth}");

        if (_currentHealth <= 0f)
        {
            _currentHealth = 0;
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Игрок умер.");
    }
}
