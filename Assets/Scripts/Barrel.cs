using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private BossArcherHealth instance;
    GameObject trigger; 

    private void Start()
    {
        trigger = GameObject.Find("TriggerEntrance");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            trigger.transform.GetChild(0).gameObject.SetActive(true);
            trigger.transform.GetChild(1).gameObject.SetActive(true);
            instance = GameObject.Find("BossArcher").GetComponent<BossArcherHealth>();
        }
        if (instance.deadArcher)
        {
            trigger.transform.GetChild(0).gameObject.SetActive(false);
            trigger.transform.GetChild(1).gameObject.SetActive(false);
            Destroy(trigger.transform.GetChild(0).gameObject);
        }
    }
}
