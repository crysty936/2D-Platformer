using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSP : MonoBehaviour {
    public GameObject ObjectWhereToGo;
   public float x, y;

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if(collision.gameObject.name=="Player"&&gameObject.name=="Sp1")
        //{
        //    
        //    x = sp2.GetComponent<Transform>().position.x+5;
        //    y = sp2.GetComponent<Transform>().position.y;
        //    collision.gameObject.transform.position= new Vector3(x, y, transform.position.z);
            

        //}
        if (collision.gameObject.tag == "Player")
        {
           
            x = ObjectWhereToGo.GetComponent<Transform>().position.x+2;
            y = ObjectWhereToGo.GetComponent<Transform>().position.y;
            if (Input.GetButtonDown("Fire1"))
            { collision.gameObject.transform.position = new Vector3(x, y, transform.position.z); }

        } 
    }
}
