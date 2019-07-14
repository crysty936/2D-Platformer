using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {
    public float x;
    public float speed;
    
	// Use this for initialization
	void Start () {
        
        speed = 1;
        x = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        //Metoda mea
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        x -= Time.deltaTime * speed;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
	}
}
