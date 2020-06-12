using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer = 0f;
    private float coolDown = 3f;
    public GameObject zombie1, zombie2;
    public Transform zombiePos1, zombiePos2;

    private void Update()
    {
        if (ZombieHealthManager.instance.isDead)
        {
            Debug.Log("is dead");
            timer += Time.deltaTime;
        }
        if(timer >= coolDown)
        {
            if(GameObject.FindGameObjectWithTag("Zombie1") == null)
            {
                Instantiate(zombie1, zombiePos1.transform.position, Quaternion.identity);
                ZombieHealthManager.instance.isDead = false;
                timer = 0f;
            }
            if (GameObject.FindGameObjectWithTag("Zombie2") == null)
            {
                Instantiate(zombie2, zombiePos2.transform.position, Quaternion.identity);
                ZombieHealthManager.instance.isDead = false;
                timer = 0f;
            }
        }
    }
}
