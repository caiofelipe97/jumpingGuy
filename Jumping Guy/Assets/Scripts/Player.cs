using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    private Vector2 movement = new Vector2(1, 1);
    private double jumpTime;
    private double landTime;
    private bool onFloor = true;
    private int combo = 1;
    private int INTERVAL_BETWEEN_JUMPS = 60;
    private int WALKING_TIME_LIMIT = 3000;


    Animator player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Animator>();

    }



    // Update is called once per frame
    void Update()
    {    
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        double currentTime = (new TimeSpan(DateTime.Now.Ticks)).TotalMilliseconds;
        double timeOnAir = currentTime - jumpTime;
        double timeOnFloor = currentTime - landTime;
        double jumpForce = WALKING_TIME_LIMIT / timeOnFloor;

        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        if (Input.GetMouseButton(0) && onFloor && timeOnAir >= INTERVAL_BETWEEN_JUMPS)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5* combo), ForceMode2D.Impulse);
            player.SetTrigger("Jump");
            onFloor = false;
            jumpTime = currentTime;

            if (timeOnFloor <= 50)
            {
                combo++;
            }
            else if(combo>1)
            {
                combo--;
            }
        }
        
        //float minLeft = -4.6f;
        //float maxRight = 11.48f;
        ////if (!onFloor)
        ////{
        ////    float xUpdate = Input.acceleration.x;
        ////    if (xUpdate < minLeft)
        ////    {
        ////        xUpdate = minLeft;
        ////    }
        ////    if (xUpdate > maxRight)
        ////    {
        ////        xUpdate = maxRight;
        ////    }
        ////    transform.Translate(xUpdate, 0, 0);
        ////}
        ////else
        ////{
        ////    transform.Translate(0, 0, 0);
        ////}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Floor")
        {
            onFloor = true;
            landTime = (new TimeSpan(DateTime.Now.Ticks)).TotalMilliseconds;
        }

    }
}