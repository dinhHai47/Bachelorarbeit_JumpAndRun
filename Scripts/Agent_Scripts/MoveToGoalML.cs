using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MoveToGoalML : Agent
{
    public Transform finish;

    public PlayerMovement mover;

    private Vector2 startingPosition;
    private float travelledDistance;
    private float MaxDistance;
    public float horizontalMove;

    private float startPosX;

    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask isGround;
    public Spawn_coins coinSpawner;

    public Animator playerAnimator;

    public override void Initialize()
    {
        startingPosition = transform.position;
        startPosX = transform.position.x;
        MaxDistance = Math.Abs(finish.transform.position.x - startPosX);
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
       

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        
        if(actions.DiscreteActions[1] == 1)
        {
            horizontalMove = -1;
        }
        if(actions.DiscreteActions[1] == 2)
        {
            horizontalMove = 1;
        }
        if(actions.DiscreteActions[1] == 0)
        {
            horizontalMove = 0;
        }
        
       
        

        mover.horizontalMove(horizontalMove);
        
        if(isGrounded() && actions.DiscreteActions[0] == 1){
            mover.jump();
           
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

        AddReward(-1f / MaxStep);
  
        if(StepCount == MaxStep)
        {
            if (transform.position.x > startPosX)
            {
                AddReward(Math.Abs((transform.position.x - startPosX))/ MaxDistance);
            }
        }
      
    }

    


public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionOut = actionsOut.DiscreteActions;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            discreteActionOut[1] = 1;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            discreteActionOut[1] = 2;
        }
        else
        {
            discreteActionOut[1] = 0;
        }

        discreteActionOut[0] = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            discreteActionOut[0] = 1;
        }
    }


    private bool isGrounded()
    {
        float extraHeighText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeighText, isGround);
     

        return raycastHit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Coin")
        {
            AddReward(+0.05f);
        }
        if (collision.tag == "Traphole")
        {
            SetReward(-1f);
            EndEpisode();
        }

        if (collision.tag == "Finish")
        {
            SetReward(+1f);
            EndEpisode();
        }
    }

    public override void OnEpisodeBegin()
    {
        Reset();
    }

    private void Reset()
    {
        //Reset Position
        transform.position = startingPosition;
        //travelledDistance = finish.transform.position.x - transform.position.x;
        //bestDistance = travelledDistance;

        //Spawn Coins
        coinSpawner.DestroyAllCoins();
        coinSpawner.InstantiateCoins();
    }

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
