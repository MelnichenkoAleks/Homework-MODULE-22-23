using UnityEngine;

public class AgentCharacterController : Controller
{
    private AgentCharacter _character;

    private GameObject _markerPrefab;
    private GameObject _currentMarker;

    private int _leftMouseButton = 0;

    private float _markerCoefficient = 0.1f;

    public AgentCharacterController(
        AgentCharacter character,
        GameObject markerPrefab)
    {
        _character = character;
        _markerPrefab = markerPrefab;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        HandleMouseInput();
        UpdateRotation();
    }

    private void HandleMouseInput()
    {
        if (_character.GetComponent<Health>() == null || !_character.GetComponent<Health>().IsAlive)
            return;

        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _character.SetDestination(hit.point);

                if (_currentMarker != null)
                    Object.Destroy(_currentMarker);

                _currentMarker = Object.Instantiate(
                    _markerPrefab,
                    hit.point + Vector3.up * _markerCoefficient, Quaternion.identity);
            }
        }
    }

    private void UpdateRotation()
    {
        Vector3 velocity = _character.CurrentVelosity;
        if (velocity.sqrMagnitude > _markerCoefficient)
        {
            _character.SetRotationDirection(velocity);
        }
    }
}
