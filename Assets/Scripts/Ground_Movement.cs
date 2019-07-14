using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Movement : MonoBehaviour {
    public float x;
    public float y;
    public float x1 = 10;
    public float xtrue;
    public float x2 = 10;
    public float ytrue;
    public int moveX;
    public int movespeed = 5;
	// Use this for initialization
	void Start () {
        x = gameObject.GetComponent<Transform>().position.x;
        xtrue = x;
        y = gameObject.GetComponent<Transform>().position.y;
        ytrue = y;
        moveX = 1;
     
    }
	
	// Update is called once per frame
	void Update () {
       Miscare3();

        x = gameObject.GetComponent<Transform>().position.x;
        if (x >= xtrue+x2)
             moveX = -1;
        if (x <= xtrue - x1)
             moveX = 1;
    }


    void Miscare3()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * movespeed, 0 );
      
      
    }
    
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    { //collision.transform.position = new Vector3(collision.transform.position.x + transform.position.x, collision.transform.position.y, 0);
          
    //        collision.rigidbody.isKinematic = true;
    //       collision.collider.transform.SetParent(gameObject.transform);
    //        //collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x + GetComponent<Rigidbody2D>().velocity.x, collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
        
    //}
}
