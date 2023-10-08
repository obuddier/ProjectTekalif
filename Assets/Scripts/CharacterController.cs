using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public float playerSpeed;
    private bool m_FacingRight = true;
    public Animator animator;

    // Update is called once per frame
    private void Start()
    {
        animator.SetBool("IsWalking", false);
    }
    void Update()
    {
        Walk();  

    }

    private void Walk()
    {
        float playerMovement = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        transform.Translate(playerMovement, 0, 0);

        if (playerMovement > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (playerMovement < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        if (playerMovement > 0)
        {
            animator.SetBool("IsWalking", true);
        }
        
        else if (playerMovement < 0)
        {
            animator.SetBool("IsWalking", true);
        }

        else
        {
            animator.SetBool("IsWalking",false); 
        }


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
