using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    #region Exposed
    Animator animator;


    public int Health; // garde une trace de la santée du joueur
    public int maxHealth = 50;
    public Image healthBar;


    #endregion



    #region Unity Lifecycle
    void Awake()
    {
        //va chercher
        animator = GetComponent<Animator>();
        //healthBar = GetComponent<Image>();

    }

    void Start()
    {
        maxHealth = Health;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(Health / maxHealth, 0, 1);
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
            StartCoroutine(WaitForAnimation());
            //Destroy(gameObject);
        }
    }

    //detruit le gameObjet apres l'animation
    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Destroy(gameObject);
    }



    #endregion



    #region Private & Protected

    #endregion
}
