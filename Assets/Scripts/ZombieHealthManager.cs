using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthManager : MonoBehaviour
{
    public int zombieMaxHealth;
    public int zombieCurrentHealth;
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
            // kill player
        }
    }

    public void HurtZombie(int damageAmount)
    {
        zombieCurrentHealth -= damageAmount;
    }

    public void SetMaxHealth()
    {
        zombieCurrentHealth = zombieMaxHealth;
    }
}
