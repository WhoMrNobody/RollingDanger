using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningPlatform : MonoBehaviour
{
    [SerializeField] private Material winningMaterial;
    [SerializeField] private GameObject winningUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Player")){

            StartCoroutine(nameof(WinningRoutine));
        }
    }

    IEnumerator WinningRoutine(){

        GetComponent<MeshRenderer>().material = winningMaterial;

        winningUI.SetActive(true);

        Time.timeScale = 0.25f;

        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
