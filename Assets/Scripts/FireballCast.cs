using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCast : MonoBehaviour
{
    public Transform castPoint;
    public GameObject fireballPrefab;

    

    public void CastFireball()
    {
        Instantiate(fireballPrefab, castPoint.position, castPoint.rotation);
    }
}
