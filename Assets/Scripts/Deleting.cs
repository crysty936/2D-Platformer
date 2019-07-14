using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleting : MonoBehaviour {
    public GameObject player;
    private float x, x1;
    
    // Use this for initialization
    void Start () {

        StartCoroutine(Obiecte());
        
    }

    IEnumerator Obiecte()
    {

        yield return new WaitForSeconds(1);
        player = GameObject.FindGameObjectWithTag("Player");
        x1 = player.GetComponent<Transform>().position.x;

    }

    // Update is called once per frame
    void Update () {
        
        x = player.GetComponent<Transform>().position.x;
        if(x!=x1)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x-(x1-x), gameObject.transform.position.y, gameObject.transform.position.z);
            x = x1;
        }
        x1 = player.GetComponent<Transform>().position.x;
    }
    
    



    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Deleter collided with " + collision.gameObject+"\n");
        Destroy(collision.gameObject);
    }

   
}
