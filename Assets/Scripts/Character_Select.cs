using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Select : MonoBehaviour {

	public void ChooseCharacter(int CharacterIndex)
    {
        PlayerPrefs.SetInt("Selectedcharacter", CharacterIndex);
        


    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Prototipul1");
    }

     void Update()
    {
        print("The Player Index is " + PlayerPrefs.GetInt("Selectedcharacter"));
    }

}
