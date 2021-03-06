﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthManager : MonoBehaviour
{
    public int zombieMaxHealth;
    public int zombieCurrentHealth;
    public bool isDead;
    public static ZombieHealthManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        isDead = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieCurrentHealth <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

    public void HurtZombie(int damageAmount)
    {
        zombieCurrentHealth -= damageAmount;
        StartCoroutine(zombieDamageFeedback());
    }

    public void SetMaxHealth()
    {
        zombieCurrentHealth = zombieMaxHealth;
    }

    IEnumerator zombieDamageFeedback()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

    }
}
