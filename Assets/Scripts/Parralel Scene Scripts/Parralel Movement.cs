using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralelJumping : MonoBehaviour {

    public float distancetosideofplayer;
    public float moveX;
    public float JumpForce = 15;
    public float sidespeed = 5;
	// Use this for initialization
	void Start () {
		





	}
	
	// Update is called once per frame
	void Update () {
		
        




	}

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        if(moveX==1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(sidespeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Rigidbody2D>().velocity = Vector2.up * JumpForce;

        }



    }









    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);

        //if(hit.distance<distancetosideofplayer)
        //{

        //}


    }





}
