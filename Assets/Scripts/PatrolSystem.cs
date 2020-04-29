using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSystem : MonoBehaviour
{
    public Transform rayStartPos, rayEndPos;
    public Transform minPatrolPos, maxPatrolPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool spotted = false;
    [SerializeField] private bool facingLeft = false;
    private Transform target;
    private Movement instance;
    

    private void Start()
    {
        InvokeRepeating("Patrol", 0f, Random.Range(2f, 6f));
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        instance = GameObject.Find("Player").GetComponent<Movement>();
    }
   
    void Update()
    {
        Raycasting();
        PatrolMovement();
    }

    void Raycasting()
    {
        Debug.DrawLine(rayStartPos.position, rayEndPos.position, Color.green);
        spotted = Physics2D.Linecast(rayStartPos.position, rayEndPos.position, 1 << LayerMask.NameToLayer("Player"));
    }

    void Patrol()
    {
        facingLeft = !facingLeft;

        if(facingLeft == true)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void PatrolMovement()
    {
        float step = moveSpeed * Time.deltaTime;
        //Vector3.Distance(transform.position, minPatrolPos.position) < 0.001f
        if (Vector3.Distance(transform.position, minPatrolPos.position) < 0.3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, maxPatrolPos.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, minPatrolPos.position, step);
        }

        if(spotted == true && instance.isGrounded)
        {
            ChasePlayer();
        }
    }

    public void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    public float GetRange(Transform minRange, Transform maxRange)
    {
        float inRange;
        inRange = Vector2.Distance(minRange.position, maxRange.position);

        return inRange;
    }
}
