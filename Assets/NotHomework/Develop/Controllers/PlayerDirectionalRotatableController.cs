using UnityEngine;

public class PlayerDirectionalRotatableController : Controller
{
    private IDirectionalRotatable _rotatable;

    private readonly string _horizontalKey = "Horizontal";
    private readonly string _verticalKey = "Vertical";

    public PlayerDirectionalRotatableController(IDirectionalRotatable rotatable)
    {
        _rotatable = rotatable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw(_horizontalKey), 0, Input.GetAxisRaw(_verticalKey));

        _rotatable.SetRotationDirection(inputDirection);
    }
}
