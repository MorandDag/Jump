using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public TextRestart text;

    public float speed = 10f;
    public bool death = false;
    public Animator animator;

    Rigidbody2D rb;
    public LevelGenerator levSet;
    float movement = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        //movement = Input.GetAxis("Horizontal") * speed;
        movement = Input.acceleration.x * speed;

        if (gameObject.transform.position.x > levSet.levelWidth + gameObject.transform.localScale.x)
        {
            gameObject.transform.position = new Vector2(-levSet.levelWidth, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x < -levSet.levelWidth - gameObject.transform.localScale.x)
        {
            gameObject.transform.position = new Vector2(levSet.levelWidth, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.y < CameraFollow.newPos.y - 7f)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.y));
    }

    void OnDisable()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDaeth");
        LevelGenerator.deathPlayer = true;
    }
}
