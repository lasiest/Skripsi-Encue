public class FirstPersonMovementSpeedController : Singleton<FirstPersonMovementSpeedController>
{
    private PlayerCrosshair Crosshair => PlayerCrosshair.Instance;

    private readonly FirstPersonModel player = FirstPersonModel.Instance;

    private bool _alreadySended;
    //private float _playerMoveSpeedDefault;

    public float DecreasedMoveSpeed { get; set; }

    private void Update()
    {
        _alreadySended = _alreadySended && Crosshair.Target == null;
        if (!_alreadySended)
        {
            var beratSampah = Crosshair.Target.GetComponent<TrashGrabbable>().SampahInformation.beratSampah;
            DecreasedMoveSpeed = 0.1f * (beratSampah - player.MoveStrength);
            //FirstPersonController.Instance.PlayerMoveSpeed = _playerMoveSpeedDefault - _decreasedMoveSpeed;
        }
        else if (_alreadySended)
        {
            //FirstPersonController.Instance.PlayerMoveSpeed = _playerMoveSpeedDefault;
            DecreasedMoveSpeed = 0f;
        }
        _alreadySended = !_alreadySended;
    }
}