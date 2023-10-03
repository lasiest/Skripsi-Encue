using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovementSpeedController : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField]private FirstPersonController _firstPersonController;
    [SerializeField]private PlayerCrosshair _playerCrosshair;
    // private float _playerMoveSpeedDefault;
    public float _decreasedMoveSpeed;
    private bool _alreadySended;
    void Start()
    {  
        // _playerMoveSpeedDefault = _firstPersonController.PlayerMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_alreadySended && _playerCrosshair.GetGrabbedObject() != null){
            _decreasedMoveSpeed = (_playerCrosshair.GetGrabbedObject().GetComponent<TrashGrabbable>().GetComponent<Trash>().SampahInformation.beratSampah * 0.1f) - FirstPersonController.Instance.PlayerMoveStrength * 0.1f;
            // _firstPersonController.PlayerMoveSpeed = _playerMoveSpeedDefault - _decreasedMoveSpeed;
            _alreadySended = true;
        }else if(_alreadySended && _playerCrosshair.GetGrabbedObject() == null){
            // _firstPersonController.PlayerMoveSpeed = _playerMoveSpeedDefault;
            _decreasedMoveSpeed = 0f;
            _alreadySended = false;
        }
    }
}
