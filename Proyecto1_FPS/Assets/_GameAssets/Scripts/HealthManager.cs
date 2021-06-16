using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    int playerLife;
    [SerializeField]
    int maxLife;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    Text textLife;
    private void Start() {
        textLife.text = playerLife.ToString();
    }
    public void AddLife(int life) {
        playerLife += life;

        if(playerLife > maxLife) {
            playerLife = maxLife;
        }

        textLife.text = playerLife.ToString();
    }

    public void Damage(int damage) {
        playerLife -= damage;
        if(playerLife <= 0) {
            playerLife = 0;
            //gameOverPanel.SetActive(true);
        }
        textLife.text = playerLife.ToString();
    }
    
}
