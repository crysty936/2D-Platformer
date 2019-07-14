using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public GameObject player;
    public float xMin = -2;
    public float xMax = 35;
    public float yMin = -0.3f;
    public float yMax = 0 ;

	// Use this for initialization
	void Start () {
       
        if(GameObject.FindGameObjectWithTag("Player")==null)
            gameObject.GetComponent<CameraSystem>().enabled = false;
        else
            player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void LateUpdate () {
       // float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float x = player.transform.position.x;
       // float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
       //float y = player.transform.position.y+4;
        gameObject.transform.position = new Vector3(x, gameObject.transform.position.y, gameObject.transform.position.z);
	}
}
