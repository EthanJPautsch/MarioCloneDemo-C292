using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    private int jumpCount = 0;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < 1)
        {
            Jump();
            jumpCount += 1;
        }
        Move();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        //(1, 0)
        //new Vector2(1, 0)
        transform.Translate(moveInput * Vector2.right * moveSpeed * Time.deltaTime);
        // (5,0) (-5,0)
    }
    private void Jump()
    {
        // (0.1)
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
            if (collision.gameObject.tag == "KillBox")
            {
                Destroy(gameObject);
            }
        }
    }
}
