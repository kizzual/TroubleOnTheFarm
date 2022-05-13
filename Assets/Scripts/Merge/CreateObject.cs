using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour
{
    [SerializeField] private TypeOfObjects objectType;
    [SerializeField] private List<Transform> cells;
    [SerializeField] private Transform parentWhenMoving;
    [SerializeField] private GameObject prefab;

    public int SavedObjectsCount;
    public int check;
    private void Start()
    {
        if (PlayerPrefs.HasKey("SaveCount"))
        {
            SavedObjectsCount = PlayerPrefs.GetInt("SaveCount");
        }
        else
        {
            SavedObjectsCount = 0;
        }
        LoadObjects();
    }
    public void CreateObjectInPanel(int value)
    {
        if(value == 1)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();
                
                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Goose_1_name, objectType.Goose_1_price, objectType.Goose_1_sprite);
            }
            else
            {
                Debug.Log("Not Enough free cells");
            }
        }
        else if(value == 2)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();

                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Goat_1_name, objectType.Goat_1_price, objectType.Goat_1_sprite);
            }
            else
            {
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 3)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();

                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Ostrich_1_name, objectType.Ostrich_1_price, objectType.Ostrich_1_sprite);
            }
            else
            {
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 4)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();

                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Pig_1_name, objectType.Pig_1_price, objectType.Pig_1_sprite);
            }
            else
            {
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 5)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();

                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Cow_1_name, objectType.Cow_1_price, objectType.Cow_1_sprite);
            }
            else
            {
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 6)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();

                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Horse_1_name, objectType.Horse_1_price, objectType.Horse_1_sprite);
            }
            else
            {
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 7)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();

                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Sheep_1_name, objectType.Sheep_1_price, objectType.Sheep_1_sprite);
            }
            else
            {
                Debug.Log("Not Enough free cells");
            }
        }
        else if (value == 8)
        {
            Transform freeCell = FindFreeCells();
            if (freeCell != null)
            {
                var go = Instantiate(prefab, freeCell.position, parentWhenMoving.rotation, freeCell.transform).GetComponent<Object>();

                go._parentWhenMoving = parentWhenMoving;
                go.Initialize(objectType.Chicken_1_name, objectType.Chicken_1_price, objectType.Chicken_1_sprite);
            }
            else
            {
                Debug.Log("Not Enough free cells");
            }
        }
    }
    private Transform FindFreeCells()
    {
        foreach (var cell in cells)
        {
            if(cell.transform.childCount < 1)
            {
                return cell;
            }
        }
        return null;
    }

    #region SAVE / LOAD / DELETE
    public void SaveObjects()
    {
        foreach (var tmp in cells)
        {
            if (tmp.childCount > 0)
            {
                if (tmp.GetChild(0).TryGetComponent(out Object obj))
                {
                    TempSave tempSave = new TempSave();
                    tempSave.saveObjects = new List<SaveObjectPosition>();
                    tempSave.saveObjects.Add(new SaveObjectPosition(obj));
                    PlayerPrefs.SetString("SaveCell" + SavedObjectsCount, JsonUtility.ToJson(tempSave));
                    SavedObjectsCount++;
                    Debug.Log("Saved");
                }
            }
        }
        PlayerPrefs.SetInt("SaveCount", SavedObjectsCount);
    }

    public void LoadObjects()
    {
        for (int i = 0; i < SavedObjectsCount; i++)
        {
            var loadSave = JsonUtility.FromJson<TempSave>(PlayerPrefs.GetString("SaveCell" + i));
            Debug.Log(loadSave);
            var go = Instantiate(prefab, loadSave.saveObjects[0].parentPosition.position, parentWhenMoving.rotation, loadSave.saveObjects[0].parentPosition.transform).GetComponent<Object>();
            go._parentWhenMoving = parentWhenMoving;
            go.Initialize(loadSave.saveObjects[0].name, loadSave.saveObjects[0].price, loadSave.saveObjects[0].sprite);
            Debug.Log("Loaded");
        }
    }
    public void DeleteSave()
    {
        for (int i = 0; i < SavedObjectsCount; i++)
        {
            PlayerPrefs.DeleteKey("SaveCell" + i);
        }
        SavedObjectsCount = 0;
    }
    #endregion

}
