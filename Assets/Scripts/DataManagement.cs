using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class DataManagement : MonoBehaviour {

    public static DataManagement datamanagement;
    public int HighScore;
    public int TotalScore;
     void Awake()
    {
        if (datamanagement == null)
        {
            DontDestroyOnLoad(gameObject);
            datamanagement = this;
        }
        else if (datamanagement != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        BinaryFormatter BinForm = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        GameData data = new GameData();
        data.HighScore = HighScore;
        data.TotalScore =TotalScore;
        BinForm.Serialize(file, data);
        file.Close();
    }
   
    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            GameData data = (GameData)BinForm.Deserialize(file);
            file.Close();
            HighScore = data.HighScore;
            TotalScore = data.TotalScore;

        }

    }

    }

[Serializable]
class GameData
{
    public int HighScore;
    public int TotalScore;
}