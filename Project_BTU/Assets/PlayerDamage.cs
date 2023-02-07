using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    #region Exposed

    public EnemyHealth enemyPlayer;
    public int damage = 3;

    #endregion



    #region Unity Lifecycle
    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }

    void FixedUpdate()
    {

    }
    #endregion



    #region Methods

    // la fonction est appelé quand qqch entre/touche le collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") // check si un gameObjet a un tag "player"
        {
            enemyPlayer.TakeDamage(damage);
        }
    }

    #endregion



    #region Private & Protected

    #endregion
}
