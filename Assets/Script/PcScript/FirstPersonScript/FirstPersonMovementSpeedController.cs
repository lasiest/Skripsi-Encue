using UnityEngine;

public class FirstPersonMovementSpeedController : MonoBehaviour
{
    private PlayerCrosshair crosshair;
    private FirstPersonModel player;
    private bool _alreadySended;
    //private float _playerMoveSpeedDefault;

    public float DecreasedMoveSpeed { get; set; }

    private void Start() => Setup();

    private void Setup()
    {
        crosshair = GetComponent<PlayerCrosshair>();
        player = GetComponent<FirstPersonModel>();
    }

    private void Update()
    {
        var grabbedTrash = crosshair.Target?.GetComponent<TrashGrabbable>();
        if (!_alreadySended && grabbedTrash != null)
        {
            var beratSampah = grabbedTrash.SampahInformation.beratSampah;
            DecreasedMoveSpeed = 0.1f * (beratSampah - player.MoveStrength);
            //player.MoveSpeed = _playerMoveSpeedDefault - DecreasedMoveSpeed;
            _alreadySended = true;
        }
        else if (_alreadySended && grabbedTrash == null)
        {
            //player.MoveSpeed = _playerMoveSpeedDefault;
            DecreasedMoveSpeed = 0f;
            _alreadySended = false;
        }
    }
}