using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private bool inRange = false;
    [SerializeField] private int swordDamage;
    public Transform attackRangeStartPos, attackRangeEndPos;

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

        if (Physics2D.Linecast(attackRangeStartPos.position, attackRangeEndPos.position, 1 << LayerMask.NameToLayer("Zombie")))
        {
            whatItHit = Physics2D.Linecast(attackRangeStartPos.position, attackRangeEndPos.position, 1 << LayerMask.NameToLayer("Zombie"));
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && inRange == true)
        {
            // do damage
            whatItHit.collider.gameObject.GetComponent<ZombieHealthManager>().HurtZombie(swordDamage);
            if(whatItHit.collider.gameObject.GetComponent<ZombieHealthManager>().zombieCurrentHealth <= 0)
            {
                Destroy(whatItHit.collider.gameObject);
            }
        }
    }
}
