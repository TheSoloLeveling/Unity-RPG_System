using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : CharacterStats
{
    private NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public override void Die()
    {
        base.Die();
        StartCoroutine(DoDie());
        
    }

    IEnumerator DoDie()
    {
        EnemyAnimator.instance.DeathAnimation();
        agent.speed = 0;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
