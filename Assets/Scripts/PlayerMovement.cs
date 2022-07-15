using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] float _speed = 10f;
    [SerializeField] float _jumpSpeed = 10f;
    private Rigidbody _rg;
    private float _hozInput, _verInput;
    private bool _isJumButtonPressed;
    private bool _isGrounded;
    void Awake() {
        
        _rg = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {
        _hozInput = Input.GetAxis("Horizontal");
        _verInput= Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Space)){
            _isJumButtonPressed=true;
        }
    }

    void FixedUpdate() {
        
        Vector3 playerMovement = new Vector3(_hozInput, 0, _verInput);
        playerMovement *= _speed;
        _rg.AddForce(playerMovement, ForceMode.Acceleration);

        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, transform.localScale.x / 2f + 0.01f)){

            _isGrounded=true;

        }else{
            _isGrounded=false;
        }

        if(_isJumButtonPressed && _isGrounded){

            _rg.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
            _isJumButtonPressed=false;
        }
    }

    /*private void OnCollisionEnter(Collision other) {
        
        _isGrounded=true;
    }

    private void OnCollisionExit(Collision other) {
        
        _isGrounded=false;
    }*/
}
