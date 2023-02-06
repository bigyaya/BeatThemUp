using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    #region Exposed

    public int runSpeed = 1;

    float horizontal;
    float vertical;
    bool facingRight;

    Animator animator;

    #endregion



    #region Unity Lifecycle
    void Awake()
{
        //cherche le composant des animations (Animator)
        animator = GetComponent<Animator>();
}

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        animator.SetFloat("Speed", Mathf.Abs(horizontal != 0 ? horizontal : vertical));
    }

void FixedUpdate()
{
        //création des mouvements static sur les axes
        Vector3 movement = new Vector3(horizontal * runSpeed, vertical * runSpeed, 0.0f);
        transform.position = transform.position + movement * Time.deltaTime;

        Flip(horizontal);
}
    #endregion



    #region Methods
    
    private void Flip(float horizontal)
    {
        if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight )
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    #endregion



    #region Private & Protected

    #endregion
}
