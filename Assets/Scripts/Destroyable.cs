using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if(hit.distance<0.8f &&hit.collider.tag=="Player")
        {
            GameObject player;
            player = hit.collider.gameObject;
           player.GetComponent<Player_Movement_Behaviour>().playerSpeed = 40;
            Destroy(gameObject);
        }
	}
}
