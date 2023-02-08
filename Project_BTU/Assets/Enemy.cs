using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    #region Exposed

    public float speed;
    public float chaseDistance;
    public float stopDistance;
    //le hero
    public GameObject target;

    private float targetDistance;

    Animator animator;
    AudioSource punchSound;


    #endregion



    #region Unity Lifecycle
    void Awake()
{

}

 void Start()
    {
        animator = GetComponent<Animator>();
        punchSound = GetComponent<AudioSource>();
    }

 void Update()
    {
        targetDistance = Vector2.Distance(transform.position, target.transform.position);
        if (targetDistance < chaseDistance && targetDistance > stopDistance)
        {
            ChasePlayer();
        }
        else
        {
            stopChasePlayer();
        }
    }

   

    void FixedUpdate()
{

}
    #endregion



    #region Methods

    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        animator.SetBool("IsWalking", true);
        animator.SetBool("IsAttacking", false);
        Punch();

    }
    void Punch()
    {
        punchSound.Play();
    }
    private void stopChasePlayer()
    {
        animator.SetBool("IsAttacking", true);

        //ne rien faire
    }


    #endregion



    #region Private & Protected

    #endregion
}
