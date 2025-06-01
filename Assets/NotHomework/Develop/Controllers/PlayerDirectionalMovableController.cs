using UnityEngine;

public class PlayerDirectionalMovableController : Controller
{
    private IDirectionalMovable _movable;

    private readonly string _horizontalKey = "Horizontal";
    private readonly string _verticalKey = "Vertical";

    public PlayerDirectionalMovableController(IDirectionalMovable movable)
    {
        _movable = movable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw(_horizontalKey), 0, Input.GetAxisRaw(_verticalKey));

        _movable.SetMoveDirection(inputDirection);
    }
}
