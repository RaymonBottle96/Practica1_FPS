using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] public float life;
    public Image lifeBar;
    void Update()
    {
       life = Mathf.Clamp(life, 0, life);

       lifeBar.fillAmount = life / 100;
    }
}
