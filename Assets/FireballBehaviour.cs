using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    private float curTime;
    private int damageBetweenSeconds = 2;
    private FireballCast fireball;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        fireball = GameObject.Find("BossArcher").GetComponent<FireballCast>();
        fireball.CastFireball();
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (timer <= 0)
        {
            animator.SetTrigger("RadialFireball");
           
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
