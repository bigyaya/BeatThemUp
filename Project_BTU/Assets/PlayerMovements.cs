using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    #region Exposed

    Animator animator;

    //run
    public int runSpeed = 1;
    float horizontal;
    float vertical;
    bool facingRight;

    //jump
    Rigidbody2D rigidbody1;
    float axisY;
    bool isJumping;
    public float jumpForce = 300;

    //Attack
    bool isAttacking;


    #endregion



    #region Unity Lifecycle
    void Awake()
    {
        //cherche le composant des animations (Animator)
        animator = GetComponent<Animator>();

        //cherche le composant rigidbody 
        rigidbody1 = GetComponent<Rigidbody2D>();
        rigidbody1.Sleep();

    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        animator.SetFloat("RunSpeed", Mathf.Abs(horizontal != 0 ? horizontal : vertical));

        //faire attaquer le personnage
        if (Input.GetButton("Attack"))
        {
            isAttacking = true;
            if (vertical != 0 || horizontal != 0)
            {
                vertical = 0;
                horizontal = 0;
                animator.SetFloat("Speed", 0);

                animator.SetTrigger("AttackCombo");
            }
        }


        //faire sauter le personnage

        if (transform.position.y <= axisY)
        {
            OnLanding();
        }

        if (Input.GetButton("Jump") && !isJumping)
        {
            axisY = transform.position.y;
            isJumping = true;
            rigidbody1.gravityScale = 1.5f;
            rigidbody1.WakeUp();
            rigidbody1.AddForce(new Vector2(transform.position.x + 7.5f, jumpForce));
            animator.SetBool("IsJumping", isJumping);
        }


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
        if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void OnLanding()
    {
        isJumping = false;
        rigidbody1.gravityScale = 0f;
        rigidbody1.Sleep();
        axisY = transform.position.y;
        animator.SetBool("IsJumping", false);
    }

    #endregion



    #region Private & Protected

    #endregion
}
