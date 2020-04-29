using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    PlayerHealthManager playerHealth;

    private void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerHealth.playerCurrentHealth < playerHealth.playerMaxHealth)
        {
            Destroy(gameObject);
            playerHealth.playerCurrentHealth++;
        }
    }
}
