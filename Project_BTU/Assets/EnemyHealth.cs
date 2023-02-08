using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    #region Exposed
    Animator animator;


    public int health; // garde une trace de la santée du joueur
    public int maxHealth = 10;
    //public HealthBarBehaviour healthbar;



    #endregion



    #region Unity Lifecycle
    void Awake()
    {
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        health = maxHealth;
        //healthbar.SetHealth(health, maxHealth);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {

    }
    #endregion



    #region Methods

    //  le joueur/personnage reçois des dégats
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            animator.SetTrigger("Dead");
            //Destroy(gameObject);
        }
    }

    //private void Destroy(string v)
    //{
    //    throw new NotImplementedException();
    //}

    #endregion



    #region Private & Protected

    #endregion
}
