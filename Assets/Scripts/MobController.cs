using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Random = System.Random;

public class MobController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    public ParticleSystem slash_ps;
    public Transform goal;
    [SerializeField] private float speed;
    public NavMeshAgent agent;
    [SerializeField] private float cooldownTime = 5f;
    private bool canAttack = true;
    public bool isAttacking = false;
    public Rigidbody rb;
    Random random = new Random();
    
    [SerializeField] private EnemySoundManager enemySounds;


    private void Awake()
    {
        
    }

    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent.enabled = true;
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("CANIPEDE CAN ATTACK - " + canAttack);
        agent.enabled = true;
        agent.destination = goal.position;
        agent.speed = speed;
        
    }

    void FixedUpdate()
    {
        double n = random.NextDouble();

        if (agent.enabled && agent.GetPathRemainingDistance() <= agent.stoppingDistance && n>=0.7)
        {
            agent.enabled = false;
            DoHeavyAttack();
        }

        if (agent.enabled && agent.GetPathRemainingDistance() <= agent.stoppingDistance && n<0.7)
        {
            agent.enabled = false;
            DoLightAttack();
        }

        //else if (agent.enabled && agent.remainingDistance > agent.stoppingDistance + 2)
        //{
        //    agent.enabled = false;
        //    DoHeavyAttack();
        //}

    }

    private void DoLightAttack()
    {

        if (canAttack == false)
            return;
        canAttack = false;
        isAttacking = true;
        //Debug.Log("CANIPEDE IS ATTACKING");
        animator.SetTrigger("light_attack");
        enemySounds.PlayLightAttackSound();
        //Debug.Log("Light attack");

    }

    private void DoHeavyAttack()
    {

        if (canAttack == false)
            return;
        canAttack = false;
        isAttacking = true;
        animator.SetTrigger("heavy_attack");
        enemySounds.PlayHeavyAttackSound();
    }

    private void StartCooldown()
    {
        //Debug.Log("COOLDOWN CALLED");
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        //Debug.Log("COOLDOWN CALLED");
        StartCoroutine(ResetAttackBool());
        agent.enabled = true;
        yield return new WaitForSeconds(cooldownTime);
        canAttack = true;
    }

    private IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(cooldownTime);  
        isAttacking = false;
    }

    public void StartKnockback()
    {

        animator.SetTrigger("isAttacked");
        canAttack = false;
        Debug.Log("ENEMY IS GETTING ATTACKED BY PLAYER");
        StartCoroutine(KnockbackCooldown());
    }

    private IEnumerator KnockbackCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }

    void playCanipedeSlash() {
        slash_ps.Play();
    }

    void stopCanipedeSlash() {
        slash_ps.Stop();
    }
}
