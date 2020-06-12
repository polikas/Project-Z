using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageHealthManager : MonoBehaviour
{
    public int mageMaxHealth;
    public int mageCurrentHealth;
   
    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (mageCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HurtMage(int damageAmount)
    {
        mageCurrentHealth -= damageAmount;
        StartCoroutine(mageDamageFeedback());
    }

    public void SetMaxHealth()
    {
        mageCurrentHealth = mageMaxHealth;
    }

    IEnumerator mageDamageFeedback()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

    }
}
