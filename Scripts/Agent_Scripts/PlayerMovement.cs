using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Rigidbody2D body;




    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public void horizontalMove(float horizontalInput)
    {
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if (horizontalInput > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalInput < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

    }

    public void jump()
    {
      
        
            body.velocity = new Vector3(body.velocity.x, jumpForce);
        
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
