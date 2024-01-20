using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private FirstPersonCrosshair crosshair;

    [SerializeField] private FirstPersonInput input;

    [SerializeField] private FirstPersonModel player;

    private void Update()
    {
        if (player.IsAllowedToMove)
        {
            var _3DMovementDirectionX = transform.TransformDirection(input.GetAxisHorizontal * Vector3.right);
            var _3DMovementDirectionZ = transform.TransformDirection(input.GetAxisVertical * Vector3.forward);
            var last3DMovementDirectionY = player._3DMovementDirectionY;
            player.MoveSpeed -= DecreaseMoveSpeed();
            player._3DMovementDirection = player.MoveSpeed * (_3DMovementDirectionX + _3DMovementDirectionZ);
            player._3DMovementDirectionY = last3DMovementDirectionY + player.Gravity * Time.deltaTime;
            player.CharacterController.Move(player._3DMovementDirection * Time.deltaTime);
        }
    }

    private float DecreaseMoveSpeed()
    {
        var decreasedMoveSpeed = 0f;
        var anyGrabbable = crosshair.Target?.GetComponent<IGrabbable>();
        if (!player.HasGrabbed && anyGrabbable != null)
        {
            var moveStrength = 2f * player.StrengthMultiplier;
            decreasedMoveSpeed = 0.1f * (anyGrabbable.Weight - moveStrength);
            player.HasGrabbed = true;
        }
        else if (player.HasGrabbed && anyGrabbable == null)
        {
            player.HasGrabbed = false;
            decreasedMoveSpeed = 0f;
        }
        return decreasedMoveSpeed;
    }
}