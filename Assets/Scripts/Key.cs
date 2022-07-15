using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Door DoorToUnlock;
    [SerializeField] private float keyRotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * keyRotationSpeed);
    }

    private void OnTriggerEnter(Collider coll) {
        
        if(coll.gameObject.tag == "Player"){

            DoorToUnlock.UnlockDoor();
            Destroy(gameObject);
        }

    }

    private void OnDrawGizmos() {
        
        if(DoorToUnlock != null){

            Gizmos.color=Color.green;
            Gizmos.DrawRay(transform.position, DoorToUnlock.transform.position - transform.position);

        }else{

            Gizmos.color=Color.red;
            Gizmos.DrawSphere(transform.position + Vector3.up * 2, 0.5f);
        }
    }
}
