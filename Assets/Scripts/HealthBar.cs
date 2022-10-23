using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image Hp;
    [SerializeField] private float maxHealth;
    private float health;
   /* private void Awake()
    {
        hpBar = transform.Find("Hp").GetComponent<Image>();
    }*/

    private void Start()
    {
        health = maxHealth;
    }

    public void wasHit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }

        Hp.fillAmount = health / maxHealth;
    }
}
