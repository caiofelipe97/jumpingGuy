using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    private Vector2 movement = new Vector2(1, 1);
    private double jumpTime;
    private bool onFloor = true;

    Animator player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        double currentTime = (new TimeSpan(DateTime.Now.Ticks)).TotalMilliseconds;
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        if (Input.GetKeyDown("space") && onFloor && currentTime - jumpTime >= 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            player.SetTrigger("Jump");
            onFloor = false;
            jumpTime = currentTime;

        }
        
        float minLeft = -4.6f;
        float maxRight = 11.48f;
        if (!onFloor)
        {
            float xUpdate = Input.acceleration.x;
            if (xUpdate < minLeft)
            {
                xUpdate = minLeft;
            }
            if (xUpdate > maxRight)
            {
                xUpdate = maxRight;
            }
            transform.Translate(xUpdate, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Floor")
        {
            onFloor = true;
        }

    }
}