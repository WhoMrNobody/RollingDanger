using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float unlockingSpeed=2f;
    [SerializeField] private float unlockedTime = 3f;
    [SerializeField] private bool isDoorUnlocked = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(isDoorUnlocked){

            unlockedTime -= Time.deltaTime;
            transform.Translate(Vector3.down * Time.deltaTime * unlockingSpeed);

            if(unlockedTime <= 0){
                gameObject.SetActive(false);
            }
        }
    }

    public void UnlockDoor(){

        isDoorUnlocked = true;
    }

}
