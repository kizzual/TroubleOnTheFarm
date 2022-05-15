using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class SaveObjectPosition 
{


    public Transform parentPosition;
    public string name;
    public int price;
    public Sprite sprite;


    public SaveObjectPosition(Object go)
    {
   //     go.GetObjectInfo(out parentPosition, out name, out price, out sprite);
    }
}

public class TempSave
{
    public List<SaveObjectPosition> saveObjects;
}

