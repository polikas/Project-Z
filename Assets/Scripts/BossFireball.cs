using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireball : MonoBehaviour
{
    public int damage = 2;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthManager player = collision.GetComponent<PlayerHealthManager>();
        if (player != null)
        {
            player.HurtPlayer(damage);
        }



        GameObject impactSprite = Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
        Destroy(impactSprite, 0.5f);

    }
}
