using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lateral_Movement : MonoBehaviour {
    public float moveX;
    public float JumpForce = 50;
    public float sidespeed = 2000;
    public bool jumped = true; 
    
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        PlayerMove();


	}




    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        
        if (moveX >0&&jumped)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * JumpForce;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right* sidespeed);
      
            jumped = false;

        }
        if (moveX < 0 && jumped)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * JumpForce;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * sidespeed);

            jumped = false;

        }
        if (moveX==0)
        {
            jumped = true;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag=="Ground")
        {

           
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

        }



    }







}
