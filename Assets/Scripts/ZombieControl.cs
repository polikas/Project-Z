using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : MonoBehaviour
{
    [SerializeField] private bool inRange = false; 
    [SerializeField] private int zombieDamage;
    public Transform attackRangeStartPos, attackRangeEndPos;
    private float curTime = 0;
    private float damageBetweenSeconds = 2;

    RaycastHit2D whatItHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AttackRange();
    }

    void AttackRange()
    {
        Debug.DrawLine(attackRangeStartPos.position, attackRangeEndPos.position, Color.green);

        if (Physics2D.Linecast(attackRangeStartPos.position, attackRangeEndPos.position, 1 << LayerMask.NameToLayer("Player")))
        {
            whatItHit = Physics2D.Linecast(attackRangeStartPos.position, attackRangeEndPos.position, 1 << LayerMask.NameToLayer("Player"));
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (inRange == true && curTime <= 0)
        {
            curTime = damageBetweenSeconds;
            // do damage
            whatItHit.collider.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(zombieDamage);
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }
}
