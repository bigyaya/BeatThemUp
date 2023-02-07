using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    #region Exposed
    Animator animator;


    public int Health; // garde une trace de la santée du joueur
    public int maxHealth = 10;



    #endregion



    #region Unity Lifecycle
    void Awake()
    {
    animator = GetComponent<Animator>();

    }

    void Start()
    {
        Health = maxHealth;
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
        Health -= amount;
        if (Health <= 0)
        {
            animator.SetTrigger("IsDead");
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
