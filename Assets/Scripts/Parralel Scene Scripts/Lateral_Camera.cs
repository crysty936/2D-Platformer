using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lateral_Camera : MonoBehaviour {

    public GameObject player;
    public float xMin = -2;
    public float xMax = 35;
    public float yMin = -0.3f;
    public float yMax = 0;
    float y,y2;
    // Use this for initialization
    void Start()
    {

        if (GameObject.FindGameObjectWithTag("Player") == null)
            gameObject.GetComponent<CameraSystem>().enabled = false;
        else
            player = GameObject.FindGameObjectWithTag("Player");
         y = player.transform.position.y;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        y2 = player.transform.position.y;
        if(y2>y)
        {
            y = y2;

        }
        // float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        // float x = player.transform.position.x;
       
        // float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        //float y = player.transform.position.y+4;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, y, gameObject.transform.position.z);
    }
}
