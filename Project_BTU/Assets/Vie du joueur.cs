using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Viedujoueur : MonoBehaviour
{
    #region Exposed


    [SerializeField]
    int _health = 5;

    
    #endregion

    #region Unity Lifecycle
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _originHealth = _health;
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            _health--;
            float coef = _health / _originHealth;
            

            Debug.Log("Ma vie est de : " + _health);
            if (_health <= 0)
            {
                _gameManager.Defeat();

            }
        }
    }
    #endregion

    #region Methods

    #endregion

    private GameManager _gameManager;

    private float _originHealth;

    #region Private & Protected

    #endregion
}
