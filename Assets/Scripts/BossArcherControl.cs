using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArcherControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool facingLeft = false;
    private float curTime = 0;
    private float damageBetweenSeconds = 2f;
    public Transform rayStartPos, rayEndPos;
    private Transform target;
    
   

    private void Start()
    {
        InvokeRepeating("Patrol", 0f, Random.Range(2f, 6f)); 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }


    void Patrol()
    {
        facingLeft = !facingLeft;

        if (facingLeft == true)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

   
}
