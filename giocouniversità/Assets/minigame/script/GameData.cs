using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class GameData{

    private Vector3Serializable playerPosition;


	public GameData(Vector3 position)
    {
        playerPosition.Fill(position);
    }

    public Vector3 getPosition()
    {
        return playerPosition.V3;
    }
}

[System.Serializable]
public struct Vector3Serializable
{
    public float x, y, z;

    public void Fill(Vector3 v3)
    {
        x = v3.x;
        y = v3.y;
        z = v3.z;
    }

    public Vector3 V3
    {
        get { return new Vector3(x, y, z); }
    }



}