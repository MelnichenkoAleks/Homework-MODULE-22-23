using UnityEngine;

public class AgentCharacterView : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private readonly int IsDamageKey = Animator.StringToHash("IsDamage");
    private readonly int IsDeadKey = Animator.StringToHash("IsDead");

    [SerializeField] private Animator _animator;
    [SerializeField] private AgentCharacter _character;

    private string injuredLayerName = "Injured Layer";
    private float injuredThreshold = 30f;

    private int _injuredLayerIndex = -1;

    private void Awake()
    {
        if (_animator != null)
            _injuredLayerIndex = _animator.GetLayerIndex(injuredLayerName);
    }

    private void Update()
    {
        if (!_character.IsAlive)
        {
            Deading();
            return;
        }

        HandleInjuredLayer();

        if (_character.CurrentVelosity.magnitude > 0.05f)
            StartRunning();
        else
            StopRunning();
    }

    private void HandleInjuredLayer()
    {
        if (_injuredLayerIndex < 0)
            return;

        float weight = (_character.CurrentHealth <= injuredThreshold) ? 1f : 0f;
        _animator.SetLayerWeight(_injuredLayerIndex, weight);
    }

    private void StopRunning() => _animator.SetBool(IsRunningKey, false);

    private void StartRunning() => _animator.SetBool(IsRunningKey, true);

    public void TakeDamage() => _animator.SetTrigger(IsDamageKey);

    private void Deading() => _animator.SetBool(IsDeadKey, true);
}
