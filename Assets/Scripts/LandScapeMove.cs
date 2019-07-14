using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScapeMove : MonoBehaviour {
    public float speed;
    private float pos;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        pos += speed;
       // pos += player.GetComponent<Rigidbody2D>().velocity.y;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(pos, 0);	
	}
}
