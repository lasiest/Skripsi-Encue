using UnityEngine;

public class FirstPersonMovementSpeedController : MonoBehaviour
{
    private PlayerCrosshair Crosshair => PlayerCrosshair.Instance;
    //private float _playerMoveSpeedDefault;
    private float _decreasedMoveSpeed;
    private bool _alreadySended;

    private void Update()
    {
        if (!_alreadySended && Crosshair.Target != null)
        {
            _decreasedMoveSpeed = (Crosshair.Target.GetComponent<TrashGrabbable>().SampahInformation.beratSampah * 0.1f) /*- FirstPersonController.Instance.PlayerMoveStrength * 0.1f*/;
            //FirstPersonController.Instance.PlayerMoveSpeed = _playerMoveSpeedDefault - _decreasedMoveSpeed;
            _alreadySended = true;
        }
        else if (_alreadySended && Crosshair.Target == null)
        {
            //FirstPersonController.Instance.PlayerMoveSpeed = _playerMoveSpeedDefault;
            _decreasedMoveSpeed = 0f;
            _alreadySended = false;
        }
    }
}