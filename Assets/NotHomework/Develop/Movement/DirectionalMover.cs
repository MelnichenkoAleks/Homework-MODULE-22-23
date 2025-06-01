using UnityEngine;

public class DirectionalMover 
{
    private CharacterController _characterController;

    private float _movementSpeed;

    private Vector3 _currentDirection;

    public DirectionalMover(CharacterController characterController, float movementSpeed)
    {
        _characterController = characterController;
        _movementSpeed = movementSpeed;
    }

    public Vector3 CurrentVelosity { get; private set; }

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public void Update(float deltaTime)
    {
        CurrentVelosity = _currentDirection.normalized * _movementSpeed;

        _characterController.Move(CurrentVelosity * deltaTime);
    }
}
