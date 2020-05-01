using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private bool inRange = false;
    [SerializeField] private int swordDamage;
    private int maxAttacks;
    public Transform attackRangeStartPos, attackRangeEndPos;
    public bool isAttacking;
    RaycastHit2D whatItHit;
    public Animator animator;
    private Movement instance;
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        maxAttacks = 1;
        instance = GameObject.Find("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackRange();
    }

    void AttackRange()
    {
        Debug.DrawLine(attackRangeStartPos.position, attackRangeEndPos.position, Color.green);

        if (Input.GetButtonDown("Fire1") && !isAttacking && maxAttacks == 1 && instance.isGrounded)
        {
            isAttacking = true;
            maxAttacks--;
            animator.SetBool("Attacking", true);
            StartCoroutine(nextAttack());
            // do damage
            if (Physics2D.Linecast(attackRangeStartPos.position, attackRangeEndPos.position, 1 << LayerMask.NameToLayer("Zombie")))
            {
                whatItHit = Physics2D.Linecast(attackRangeStartPos.position, attackRangeEndPos.position, 1 << LayerMask.NameToLayer("Zombie"));
                whatItHit.collider.gameObject.GetComponent<ZombieHealthManager>().HurtZombie(swordDamage);
            }
            if (Physics2D.Linecast(attackRangeStartPos.position, attackRangeEndPos.position, 1 << LayerMask.NameToLayer("Mage")))
            {
                whatItHit = Physics2D.Linecast(attackRangeStartPos.position, attackRangeEndPos.position, 1 << LayerMask.NameToLayer("Mage"));
                whatItHit.collider.gameObject.GetComponent<MageHealthManager>().HurtMage(swordDamage);
            }
            if (Physics2D.Linecast(attackRangeStartPos.position, attackRangeEndPos.position, 1 << LayerMask.NameToLayer("BossArcher")))
            {
                whatItHit = Physics2D.Linecast(attackRangeStartPos.position, attackRangeEndPos.position, 1 << LayerMask.NameToLayer("BossArcher"));
                whatItHit.collider.gameObject.GetComponent<BossArcherHealth>().HurtBossArcher(swordDamage);
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isAttacking = false;
            animator.SetBool("Attacking", false);
        }
    }

    public IEnumerator nextAttack()
    {
        yield return new WaitForSeconds(1.0f);
        maxAttacks++;
        animator.SetBool("Attacking", false);
    }
}
