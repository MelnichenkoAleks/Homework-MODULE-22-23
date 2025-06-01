using UnityEngine;

public class PlayerCharacterController : Controller
{
    private Character _character;
    private readonly string _horizontalKey = "Horizontal";
    private readonly string _verticalKey = "Vertical";

    public PlayerCharacterController(Character character)
    {
        _character = character;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw(_horizontalKey), 0, Input.GetAxisRaw(_verticalKey));

        _character.SetMoveDirection(inputDirection);
        _character.SetRotationDirection(inputDirection);
    }
}
