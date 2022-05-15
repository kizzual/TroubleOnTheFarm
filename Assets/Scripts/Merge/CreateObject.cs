using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour
{
    const string filename = "SavedObjects";

    [SerializeField] private TypeOfObjects objectType;
    [SerializeField] private List<Transform> cells;
    [SerializeField] private Transform parentWhenMoving;
    [SerializeField] private GameObject prefab;

    List<Item> entries = new List<Item>();

    private void Awake()
    {
        LoadObjects();
    }
    public bool CreateObjectInPanel(int value)
    {
        if (value == 1)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();
                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Goose_1_name, objectType.Goose_1_price, objectType.Goose_1_sprite);
                return true;
            }
            else
            {
                Debug.Log("Not Enough free cells");
                return false;
            }
        }
        else if (value == 2)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();
                go.GetComponent<Image>().SetNativeSize();
                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Goat_1_name, objectType.Goat_1_price, objectType.Goat_1_sprite); 
                return true;

            }
            else
            {
                return false;
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 3)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();
                go.GetComponent<Image>().SetNativeSize();
                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Ostrich_1_name, objectType.Ostrich_1_price, objectType.Ostrich_1_sprite); 
                return true;
            }
            else
            {
                return false;
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 4)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();
                go.GetComponent<Image>().SetNativeSize();
                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Pig_1_name, objectType.Pig_1_price, objectType.Pig_1_sprite);
                return true;
            }
            else
            {
                return false;
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 5)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();
                go.GetComponent<Image>().SetNativeSize();
                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Cow_1_name, objectType.Cow_1_price, objectType.Cow_1_sprite);
                return true;
            }
            else
            {
                return false;
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 6)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();
                go.GetComponent<Image>().SetNativeSize();
                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Horse_1_name, objectType.Horse_1_price, objectType.Horse_1_sprite);
                return true;
            }
            else
            {
                return false;
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 7)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();
                go.GetComponent<Image>().SetNativeSize();
                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Sheep_1_name, objectType.Sheep_1_price, objectType.Sheep_1_sprite);
                return true;
            }
            else
            {
                return false;
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 8)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();
                go.GetComponent<Image>().SetNativeSize();
                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Chicken_1_name, objectType.Chicken_1_price, objectType.Chicken_1_sprite);
                return true;
            }
            else
            {
                return false;
                Debug.Log("Not Enough free cells");

            }
        }
        return false;
    }
    private Transform FindFreeCells()
    {
        foreach (var cell in cells)
        {
            if (cell.transform.childCount < 1)
            {
                return cell;
            }
        }
        return null;
    }
    public Sprite CheckingObjectSprite(string obj)
    {
        if(obj == objectType.Chicken_1_name)
        {
            return objectType.Chicken_1_sprite;
        }
        else if (obj == objectType.Chicken_2_name)
        {
            return objectType.Chicken_2_sprite;
        }
        else if (obj == objectType.Chicken_3_name)
        {
            return objectType.Chicken_3_sprite;
        }
        else if (obj == objectType.Chicken_4_name)
        {
            return objectType.Chicken_4_sprite;
        }
        else if (obj == objectType.Cow_1_name)
        {
            return objectType.Cow_1_sprite;
        }
        else if (obj == objectType.Cow_2_name)
        {
            return objectType.Cow_2_sprite;
        }
        else if (obj == objectType.Cow_3_name)
        {
            return objectType.Cow_3_sprite;
        }
        else if (obj == objectType.Cow_4_name)
        {
            return objectType.Cow_4_sprite;
        }
        else if (obj == objectType.Goat_1_name)
        {
            return objectType.Goat_1_sprite;
        }
        else if (obj == objectType.Goat_2_name)
        {
            return objectType.Goat_2_sprite;
        }
        else if (obj == objectType.Goat_3_name)
        {
            return objectType.Goat_3_sprite;
        }
        else if (obj == objectType.Goat_4_name)
        {
            return objectType.Goat_4_sprite;
        }
        else if (obj == objectType.Goose_1_name)
        {
            return objectType.Goose_1_sprite;
        }
        else if (obj == objectType.Goose_2_name)
        {
            return objectType.Goose_2_sprite;
        }
        else if (obj == objectType.Goose_3_name)
        {
            return objectType.Goose_3_sprite;
        }
        else if (obj == objectType.Goose_4_name)
        {
            return objectType.Goose_4_sprite;
        }
        else if (obj == objectType.Horse_1_name)
        {
            return objectType.Horse_1_sprite;
        }
        else if (obj == objectType.Horse_2_name)
        {
            return objectType.Horse_2_sprite;
        }
        else if (obj == objectType.Horse_3_name)
        {
            return objectType.Horse_3_sprite;
        }
        else if (obj == objectType.Horse_4_name)
        {
            return objectType.Horse_4_sprite;
        }
        else if (obj == objectType.Ostrich_1_name)
        {
            return objectType.Ostrich_1_sprite;
        }
        else if (obj == objectType.Ostrich_2_name)
        {
            return objectType.Ostrich_2_sprite;
        }
        else if (obj == objectType.Ostrich_3_name)
        {
            return objectType.Ostrich_3_sprite;
        }
        else if (obj == objectType.Ostrich_4_name)
        {
            return objectType.Ostrich_4_sprite;
        }
        else if (obj == objectType.Pig_1_name)
        {
            return objectType.Pig_1_sprite;
        }
        else if (obj == objectType.Pig_2_name)
        {
            return objectType.Pig_2_sprite;
        }
        else if (obj == objectType.Pig_3_name)
        {
            return objectType.Pig_3_sprite;
        }
        else if (obj == objectType.Pig_4_name)
        {
            return objectType.Pig_4_sprite;
        }
        else if (obj == objectType.Sheep_1_name)
        {
            return objectType.Sheep_1_sprite;
        }
        else if (obj == objectType.Sheep_2_name)
        {
            return objectType.Sheep_2_sprite;
        }
        else if (obj == objectType.Sheep_3_name)
        {
            return objectType.Sheep_3_sprite;
        }
        else if (obj == objectType.Sheep_4_name)
        {
            return objectType.Sheep_4_sprite;
        }
        return null;
    }
    public bool CheckParticleOnGameObject(Object obj)
    {
        if(obj.name == objectType.Chicken_4_name ||
            obj.name == objectType.Cow_4_name ||
            obj.name == objectType.Goat_4_name ||
            obj.name == objectType.Goose_4_name ||
            obj.name == objectType.Horse_4_name ||
            obj.name == objectType.Ostrich_4_name ||
            obj.name == objectType.Pig_4_name ||
            obj.name == objectType.Sheep_4_name )
        {
            return true;
        }
        return false;
    }
    #region SAVE / LOAD / DELETE
    public void SaveObjects()
    {
        entries.Clear();
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].childCount > 0)
            {
                if (cells[i].GetChild(0).TryGetComponent(out Object obj))
                {
                    entries.Add(new Item(obj));
                    Debug.Log("Saved");
                }
            }
        }
        FileHandler.SaveToJSON<Item>(entries, filename);
    }

    public void LoadObjects()
    {
        entries = FileHandler.ReadListFromJSON<Item>(filename);
        for (int i = 0; i < entries.Count; i++)
        {
            var go = Instantiate(prefab).GetComponent<Object>();
            go._parentWhenMoving = parentWhenMoving;
            go.transform.SetParent(cells[entries[i].parrentIndex].transform);
            go.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
            go.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().transform.rotation = cells[entries[i].parrentIndex].transform.rotation;
            go.Initialize(entries[i].name, entries[i].price, CheckingObjectSprite(entries[i].name));
            if (CheckParticleOnGameObject(go))
                go.TurnOnParticles();

        }
    }

    #endregion
}

[Serializable]
public class Item
{

    public string name;
    public int price;
    public int parrentIndex;

    public Item(Object obj)
    {
        obj.GetObjectInfo(out name, out price, out parrentIndex);
    }
}

