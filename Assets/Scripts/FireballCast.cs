using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCast : MonoBehaviour
{
    public Transform castPoint;
    public GameObject fireballPrefab;
    

    

    private void Start()
    {
        
    }

    public void CastFireball()
    {
        Instantiate(fireballPrefab, castPoint.position, castPoint.rotation);
    }
}
