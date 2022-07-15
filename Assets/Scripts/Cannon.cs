using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform cannonHead;
    [SerializeField] private Transform cannonTip;
    [SerializeField] private float shootingCoolDown = 3f;
    [SerializeField] private float laserPower = 50f;

    private bool _isPlayerInRange =false;
    private GameObject _player;
    private float _timeLeftToShoot = 0f;
    private LineRenderer _cannonLaser;
    // Start is called before the first frame update
    void Start()
    {
        _cannonLaser = GetComponent<LineRenderer>();
        _cannonLaser.sharedMaterial.color = Color.green;
        _cannonLaser.enabled = false;
        _player = GameObject.FindGameObjectWithTag("Player");
        _timeLeftToShoot = shootingCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isPlayerInRange){

            cannonHead.transform.LookAt(_player.transform);

            _cannonLaser.SetPosition(0, cannonTip.transform.position);
            _cannonLaser.SetPosition(1, _player.transform.position);
            _timeLeftToShoot -= Time.deltaTime;
        }

        if(_timeLeftToShoot <= shootingCoolDown * 0.5){
            _cannonLaser.sharedMaterial.color = Color.red;
        }

        if(_timeLeftToShoot <= 0){

            Vector3 directionToPushBack = _player.transform.position - cannonTip.position;
            _player.GetComponent<Rigidbody>().AddForce(directionToPushBack * laserPower, ForceMode.Impulse);
            _timeLeftToShoot=shootingCoolDown;
            _cannonLaser.sharedMaterial.color = Color.green;
        }


    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Player")){

            _isPlayerInRange= true;
            _cannonLaser.enabled=true;
        }
    }

    private void OnTriggerExit(Collider other) {
        
        if(other.CompareTag("Player")){

            _isPlayerInRange=false;
            _cannonLaser.enabled=false;
            _timeLeftToShoot=shootingCoolDown;
            _cannonLaser.sharedMaterial.color = Color.green;
        }
    }
}
