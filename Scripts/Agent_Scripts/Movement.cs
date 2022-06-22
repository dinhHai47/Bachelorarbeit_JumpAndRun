using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    public float horizontalMove = 0f;

    private bool jump = false;

    public Animator playerAnimator;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //checking the conditions when to use which animation

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            jumpAnimation();
        }
        else if (horizontalMove != 0)
        {
            walkAnimation();
        }
        else
        {
            idleAnimation();
        }


    }

    void FixedUpdate()
    {
        //Move our character (walk and jump)
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }


    //functions to activate the needed animation for each action
    private void jumpAnimation()
    {
        playerAnimator.SetBool("jump", true);
        playerAnimator.SetBool("idle", false);
        playerAnimator.SetBool("walk", false);

    }

    private void walkAnimation()
    {
        playerAnimator.SetBool("jump", false);
        playerAnimator.SetBool("idle", false);
        playerAnimator.SetBool("walk", true);

    }

    private void idleAnimation()
    {
        playerAnimator.SetBool("jump", false);
        playerAnimator.SetBool("idle", true);
        playerAnimator.SetBool("walk", false);

    }

}
