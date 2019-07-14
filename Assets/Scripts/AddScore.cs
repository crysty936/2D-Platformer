﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            player.GetComponent<Score>().score += 50;
            DestroyObject(gameObject);

        }
    }
}
