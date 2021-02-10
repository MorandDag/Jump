using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;
    public int numPlatform = 0;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
            if (col != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;

                FindObjectOfType<AudioManager>().Play("Jump");

                if(TextPoints.points < numPlatform)
                    TextPoints.points = numPlatform;
            }
        }
        
    }
    
}
