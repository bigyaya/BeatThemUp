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

    //  le personnage reçois des dégats
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            animator.SetTrigger("Dead");
            StartCoroutine(WaitForAnimation());
        }
    }

    //detruit le personnage apres l'animation
    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Destroy(gameObject);
    }


    #endregion



    #region Private & Protected

    #endregion
}
