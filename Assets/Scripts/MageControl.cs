using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageControl : MonoBehaviour
{
    
    public bool spotted = false;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool facingLeft = false;
    private float curTime = 0;
    private float damageBetweenSeconds = 2f;
    public Transform rayStartPos, rayEndPos;
    public Transform minPatrolPos, maxPatrolPos;
    private Transform target;
    private Movement instance;
    private FireballCast fireball;

    private void Start()
    {
        InvokeRepeating("Patrol", 0f, Random.Range(2f, 6f));
        instance = GameObject.Find("Player").GetComponent<Movement>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        fireball = GameObject.Find("Mage").GetComponent<FireballCast>();
    }

    private void Update()
    {
        PatrolMovement();
        Raycasting();
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

     void Raycasting()
    {
        Debug.DrawLine(rayStartPos.position, rayEndPos.position, Color.green);
        spotted = Physics2D.Linecast(rayStartPos.position, rayEndPos.position, 1 << LayerMask.NameToLayer("Player"));
    }

    void PatrolMovement()
    {
        float step = moveSpeed * Time.deltaTime;
        //Vector3.Distance(transform.position, minPatrolPos.position) < 0.001f
        if (Vector3.Distance(transform.position, minPatrolPos.position) < 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, maxPatrolPos.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, minPatrolPos.position, step);
        }

        if (spotted && instance.isGrounded && curTime <= 0)
        {
            curTime = damageBetweenSeconds;
            // cast fireball
            fireball.CastFireball();
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }

}
