using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {
   
    Rigidbody2D rb;
    public float fallM = 15;
    public float lowjumpM = 15;
    // Use this for initialization
      void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (fallM - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !( Input.touchCount>1))
        {
            GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (lowjumpM - 1) * Time.deltaTime;

        }
    }
}
