using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Behaviour : MonoBehaviour {
    public bool facingRight = true;
    public int playerSpeed=10;
    public int playerJumpPower = 40;
    public float moveX;
    GameObject inamic;
    public float DistanceToBottomOfPlayer = 1.3f;
    private Vector2 TouchOrigin = -Vector2.one;
    private float screenCenterX;
    private bool doublejump = true;
    bool onplatform;
    GameObject platform;
    // Use this for initialization
    private void Start()
    {
        
        screenCenterX = Screen.width * 0.5f;
    }

    // Update is called once per frame
    void Update () {
        Touch();
        PlayerMove();
        PlayerRaycast();
       
    }
    private void FixedUpdate()
    {
        if(onplatform)
        {
            gameObject.transform.parent = platform.transform;
            //gameObject.transform.position = new Vector3(platform.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
    void Touch()
    {

        if (Input.touchCount > 0)
        {
             gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
             if (Input.touchCount > 1)
            {
                Jump();
            }
            Touch myTouch = Input.touches[0];

            if (myTouch.phase == TouchPhase.Began)
            {
                if (myTouch.position.x < screenCenterX)
                {
                    moveX = -1;
                    gameObject.GetComponent<Animator>().SetBool("IsMoving", true);

                }
                else if (myTouch.position.x > screenCenterX)
                {
                    moveX = 1;
                    gameObject.GetComponent<Animator>().SetBool("IsMoving", true);

                }
            }
         }else
        {
            moveX = 0;
            gameObject.GetComponent<Animator>().SetBool("IsMoving", false);
        }



    }
    void PlayerMove()
    {//Controls

        moveX = Input.GetAxis("Horizontal");
        if (moveX != 0)
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        }
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Jump();
        }
        //Animations
       // if (moveX!=0)
       // {
       //     gameObject.GetComponent<Animator>().SetBool("IsMoving", true);
       // }
       //else
       //     gameObject.GetComponent<Animator>().SetBool("IsMoving", false);

        //PlayerDirection
        if (moveX>0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            facingRight = true;
        }
        else if(moveX<0.0f)
        {
           GetComponent<SpriteRenderer>().flipX = true;
            facingRight = false;
        }
        
        

    }

    void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < DistanceToBottomOfPlayer)
        {
            doublejump = true;
            
            //if(gameObject.GetComponent<Rigidbody2D>().velocity.y==0)
            GetComponent<Rigidbody2D>().velocity = Vector2.up * playerJumpPower;
        }else if(doublejump)
        {
            doublejump = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.up * playerJumpPower;
        }
    }
    
   

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
       // if (hit.distance < DistanceToBottomOfPlayer && hit.collider.tag== "Ground")
            //Debug.Log("A atins");
        if(hit.distance< DistanceToBottomOfPlayer && hit.collider.tag == "Enemy")
        {
            GameObject player;
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Score>().score += 50;
            inamic = hit.collider.gameObject;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 50;
            if(facingRight==true)
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
           else
           hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 200);
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
            hit.collider.gameObject.GetComponent<Enemy_move>().enabled = false;
     
        }



    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Platform")
        {
            platform = collision.gameObject;
            Debug.Log("A intrat pe platforma");
            this.transform.parent = collision.transform;
            onplatform = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Platform")
        {
            onplatform = false;
            this.transform.parent = null;

        }
    }



}
