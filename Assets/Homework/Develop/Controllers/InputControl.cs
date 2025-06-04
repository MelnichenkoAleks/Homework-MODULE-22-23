using UnityEngine;

public class InputControl : MonoBehaviour
{
    [SerializeField] private AgentCharacter _character;

    [SerializeField] private GameObject _markerPrefab;

    private Controller _characterController;

    private void Awake()
    {
        _characterController = new AgentCharacterController(_character, _markerPrefab);
        _characterController.Enable();
    }

    private void Update()
    {
        _characterController.Update(Time.deltaTime);
    }
}
