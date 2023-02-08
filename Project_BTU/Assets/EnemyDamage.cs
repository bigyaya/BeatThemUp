using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    #region Exposed

    public HealthPlayer healthPlayer;
    public int damage = 2;

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
        if (collision.gameObject.tag == "Player") // check si un gameObjet a un tag "player"
        {
            healthPlayer.TakeDamage(damage);
        }
    }
    


    #endregion



    #region Private & Protected

    #endregion
}
