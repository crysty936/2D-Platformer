using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Spawner : MonoBehaviour {
    public GameObject[] players;
    private int playerindex;


	// Use this for initialization
	void Start () {
        playerindex = PlayerPrefs.GetInt("Selectedcharacter");
        
            Instantiate (players[(playerindex)], Vector2.zero,Quaternion.identity);



	}
	
	
}
