using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private Rigidbody _rb;
    private GameObject _player;
    private bool _isPlayerRange = false;
    void Start()
    {
        _rb= GetComponent<Rigidbody>();
        _player=GameObject.FindGameObjectWithTag("Player");
    }

    
    void FixedUpdate()
    {
        if (_isPlayerRange){

            Vector3 targetDirection = _player.transform.position - transform.position;
            _rb.AddForce(targetDirection * _speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            Vector3 newVelocity = _rb.velocity;
            newVelocity.y = 0;

        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Player") _isPlayerRange=true;
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") _isPlayerRange=false;
    }
}
