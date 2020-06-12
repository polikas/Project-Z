using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBlast : MonoBehaviour
{
    public GameObject fireballPrefab;
    float radius, speed;
    public int numberOfFireballs;
   


    public Vector2 castPoint;

    private void Start()
    {
        radius = 5f;
        speed = 1f;
       
    }

    public void SpawnProjectiles(int numberOfFireballs)
    {
        float angleStep = 360f / numberOfFireballs;
        float angle = 0f;

        for (int i = 0; i <= numberOfFireballs - 1; i++)
        {
            
            float fireballDirXposition = castPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float fireballDirYposition = castPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 fireBallVector = new Vector2(fireballDirXposition, fireballDirYposition);
            Vector2 fireBallMoveDirection = (fireBallVector - castPoint).normalized * speed;

            var fireBall = Instantiate(fireballPrefab, castPoint, Quaternion.identity);
            fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(fireBallMoveDirection.x, fireBallMoveDirection.y);

            angle += angleStep;
        }
    }
}
