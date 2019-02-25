using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
    

public class SaveLoad : MonoBehaviour {

    public Transform playerTrasform;

    public void Save()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenWrite(destination);

        }
        else
        {
            file = File.Create(destination);
        }

        GameData data = new GameData(playerTrasform.position);

        BinaryFormatter bf = new BinaryFormatter();

        bf.Serialize(file, data);

        file.Close();

    }

    public void Load()
    {
        string destination = Application.persistentDataPath + "/save.dat";

        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenRead(destination);
        }
        else
        {
            Debug.Log("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();

        GameData data = (GameData)bf.Deserialize(file);

        file.Close();
        playerTrasform.position = data.getPosition();

    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Y))
        {
            Save();
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            Load();
        }



    }
}
