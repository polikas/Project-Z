using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArcherHealth : MonoBehaviour
{
    public int bossArcherHealth;
    public int bossArcherCurrentHealth;
    public bool deadArcher;
    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
        deadArcher = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossArcherCurrentHealth <= 0)
        {
            deadArcher = true;
            Destroy(gameObject);
        }
    }

    public void HurtBossArcher(int damageAmount)
    {
        bossArcherCurrentHealth -= damageAmount;
        StartCoroutine(bossArcherDamageFeedback());
    }

    public void SetMaxHealth()
    {
        bossArcherCurrentHealth = bossArcherHealth;
    }

    IEnumerator bossArcherDamageFeedback()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

    }
}
