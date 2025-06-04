using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float _currentHealth;

    public float Current => _currentHealth;
    public float Max => maxHealth;
    public bool IsAlive => _currentHealth > 0f;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (!IsAlive)
            return;

        _currentHealth -= damage;
        _currentHealth = Mathf.Max(_currentHealth, 0f);

        Debug.Log($"{gameObject.name} получил {damage} урона. “екущее здоровье: {_currentHealth}");

        if (_currentHealth <= 0f)
        {
            _currentHealth = 0;
            Die();
        }
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} умер.");
    }
}
