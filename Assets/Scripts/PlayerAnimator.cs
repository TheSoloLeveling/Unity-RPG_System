using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{

    #region Singleton

    public static PlayerAnimator instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public AnimationClip replaceableAttackAnim;
    public AnimationClip[] defaulAttackAnimSet;
    private AnimationClip[] currentAttackAnimSet;

    const float locomationAnmationSmoothTime = 0.1f;

    private NavMeshAgent agent;
    private Animator anim;
    private CharacterCombat combat;

    private AnimatorOverrideController overrideController;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        combat = GetComponent<CharacterCombat>();

        overrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = overrideController;

        currentAttackAnimSet = defaulAttackAnimSet;
        combat.OnAttack += OnAttack;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, 0.1f, Time.deltaTime);

        anim.SetBool("inCombat", combat.InCombat);
    }

    public void DeathAnimation()
    {
        anim.SetBool("isDead", true);
        
    }

    public void OnAttack()
    {
        anim.SetTrigger("Attack");
        int attackIndex = Random.Range(0, currentAttackAnimSet.Length);

        overrideController[replaceableAttackAnim] = currentAttackAnimSet[attackIndex];
    }
}
