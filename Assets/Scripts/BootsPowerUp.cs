using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsPowerUp : MonoBehaviour
{
    private Movement instance;

    private void Start()
    {
        instance = GameObject.Find("Player").GetComponent<Movement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            instance.bootsPowerUp = true;
            Destroy(this.gameObject);
        }
    }
}
