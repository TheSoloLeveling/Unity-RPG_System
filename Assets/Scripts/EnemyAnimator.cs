using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : MonoBehaviour
{

    #region Singleton

    public static EnemyAnimator instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion


    private NavMeshAgent agent;
    private Animator anim;

    //private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
    }

    public void DeathAnimation()
    {
        anim.SetBool("isDead", true);
    }

   
}
