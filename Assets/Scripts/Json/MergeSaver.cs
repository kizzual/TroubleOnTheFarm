using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MergeSaver : MonoBehaviour
{
    public Object _object;

    public void LoadField()
    {
        _object = JsonUtility.FromJson<Object>(File.ReadAllText(Application.streamingAssetsPath + "SaveMergeObjects"));
    }
    public void SaveField()
    {
        File.WriteAllText(Application.streamingAssetsPath + "SaveMergeObjects", JsonUtility.ToJson(_object) );
    }

    [Serializable]
    public class Object
    {
        public string name;
        public int price;
    }
}
