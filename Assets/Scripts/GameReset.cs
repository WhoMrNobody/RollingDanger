using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag== "Player"){

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
   
}
