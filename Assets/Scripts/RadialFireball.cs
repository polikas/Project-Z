using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialFireball : StateMachineBehaviour
{

    public float timer;
    public float minTime;
    public float maxTime;
    private RadialBlast instance;
    
   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        instance = GameObject.Find("BossArcher").GetComponent<RadialBlast>();
        instance.SpawnProjectiles(instance.numberOfFireballs);
        //GameObject.Find("BossArcher").GetComponent<SpriteRenderer>().color = new Color(18, 46, 253);
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        if (timer <= 0)
        {
            animator.SetTrigger("Idle");
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //GameObject.Find("BossArcher").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }
    
}
