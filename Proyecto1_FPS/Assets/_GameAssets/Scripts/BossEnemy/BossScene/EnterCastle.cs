using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCastle : MonoBehaviour
{
    public string newLevel;
    public GameObject textElement;
    private void OnTriggerStay(Collider other) {
        Debug.Log(other);

        if(other.CompareTag("Player")) {
            textElement.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) {
                SceneManager.LoadScene(newLevel);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            textElement.SetActive(false);
        }
    }
}
