using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {
    public int health;
	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y<=-7)
        {
           
            Debug.Log("Player has Died");
            StartCoroutine(Die());
            //Destroy(gameObject);

        }
        
           if(health<=0)
        {


            SceneManager.LoadScene("Prototipul1");
        }
            

        

	}
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Prototipul1");
        Debug.Log("Scene Restarted");


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
            StartCoroutine(Die());

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            health = health - 50;

    }
    

}
