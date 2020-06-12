using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int playerMaxHealth;
    public int playerCurrentHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        ManagePlayerHealth();
    }

    public void HurtPlayer(int damageAmount)
    {
        playerCurrentHealth -= damageAmount;
        StartCoroutine(playerDamageFeedback());
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    void ManagePlayerHealth()
    {
        if (playerCurrentHealth <= 0)
        {
            RespawnPlayer();
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerMaxHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            if (i < playerCurrentHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    IEnumerator playerDamageFeedback()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

    }

    public void RespawnPlayer()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
