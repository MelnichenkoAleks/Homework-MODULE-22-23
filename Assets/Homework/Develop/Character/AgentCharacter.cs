using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour
{
    private NavMeshAgent _agent;

    private AgentMover _mover;
    private DirectionalRotator _rotator;

    private Health _health;

    public float CurrentHealth => _health.Current;
    public bool IsAlive => _health.IsAlive;

    [SerializeField] private AgentCharacterView _agentCharacterView;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxHealth;

    public Vector3 CurrentVelosity => _mover.CurrentVelosity;

    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public float MaxHealth => _health.Max;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _mover = new AgentMover(_agent, _moveSpeed);
        _rotator = new DirectionalRotator(transform, _rotationSpeed);

        _health = new Health(_maxHealth);
    }

    private void Update()
    {
        _rotator.Update(Time.deltaTime);
    }

    public void SetDestination(Vector3 position) => _mover.SetDestination(position);

    public void StopMove() => _mover.Stop();

    public void ResumeMove() => _mover.Resume();

    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget)
        => NavMeshUtils.TryGetPath(_agent, targetPosition, pathToTarget);

    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);

        _agentCharacterView.TakeDamage();

        if (!_health.IsAlive)
        {
            _mover.Stop();
        }
    }
}
