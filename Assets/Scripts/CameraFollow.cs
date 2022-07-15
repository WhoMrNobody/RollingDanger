using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _cameraTarget;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime=0.3f;
    private Vector3 cameraVelocity = Vector3.zero;
    void Start()
    {
        _cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - _cameraTarget.position;
    }

   
    void LateUpdate()
    {
        Vector3 targetPos = _cameraTarget.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref cameraVelocity, smoothTime);

        transform.LookAt(_cameraTarget);
        
    }
}
