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

    private void Start()
    {
        InvokeRepeating("Patrol", 0f, Random.Range(2f, 6f));
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
        if (Vector3.Distance(transform.position, minPatrolPos.position) < 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, maxPatrolPos.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, minPatrolPos.position, step);
        }
    }
}
