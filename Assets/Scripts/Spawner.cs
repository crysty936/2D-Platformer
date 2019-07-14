using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    public GameObject player;
    public float startx;
	// Use this for initialization
	void Start () {
        StartCoroutine(Obiecte());
        
    }

    IEnumerator Obiecte() {

        yield return new WaitForSeconds(1);
        player = GameObject.FindGameObjectWithTag("Player");
        startx = player.GetComponent<Transform>().position.x;
        
    }
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x-startx>15)
        {
            spawn();
            startx = player.transform.position.x;
        }
	}




    void spawn()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Random.Range(0, 5), 0), Quaternion.identity);
        //Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+ Random.Range(0, 5), 0), Quaternion.identity);
        // Invoke("spawn", Random.Range(spawnMin, spawnMax));
    }


}
