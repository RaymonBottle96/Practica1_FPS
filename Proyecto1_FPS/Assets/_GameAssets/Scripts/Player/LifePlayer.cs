using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] public float life;
    [SerializeField] public Gun gun;
    //[SerializeField] public MonoBehaviour fps;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public Image lifeBar;
    public GameObject goPanel;
    public static bool gameOver;
    void Update()
    {
        life = Mathf.Clamp(life, 0, life);

        lifeBar.fillAmount = life / 100;
        if (life <= 0)
        {
            gameOver = true;
            goPanel.SetActive(true);
            gun.enabled = false;
            Time.timeScale = 0;
            //fps.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("FirstAid")) {
            Debug.Log("Botiquin");
            Destroy(other.gameObject);
            life += 100;
        }
    }

}
