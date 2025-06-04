using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float detectionRadius;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionDelay;
    [SerializeField] private float damage;
    [SerializeField] private GameObject explosionEffect;

    [SerializeField] private AgentCharacterView _agentCharacterView;

    private bool _isTriggered = false;
    private float _timer = 0f;

    private void Start()
    {
        SphereCollider collider = GetComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.radius = detectionRadius;
    }

    private void Update()
    {
        if (_isTriggered)
        {
            _timer += Time.deltaTime;
            if (_timer >= explosionDelay)
            {
                Explode();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isTriggered)
            return;

        if (other.TryGetComponent(out Health _))
        {
            _isTriggered = true;
            _timer = 0f;
        }
    }

    private void Explode()
    {
        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out Health health))
            {
                health.TakeDamage(damage);
                _agentCharacterView.HasDamage();
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

