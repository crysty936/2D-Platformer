using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour {
    public int movespeed = 5;
    public int moveX;
	// Use this for initialization
	void Start () {
        moveX = 1;
	}
	
	// Update is called once per frame
	void Update () {
       /* RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(moveX, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, 0) * movespeed;
        if (hit.distance<0.7f)
        {
            moveX = moveX * -1;   
        }
        */
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * movespeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
       



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="EnemyReset")
        {
            moveX = moveX * -1;

        }
    }
}
