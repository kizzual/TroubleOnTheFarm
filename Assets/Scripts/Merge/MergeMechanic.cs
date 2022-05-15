using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MergeMechanic : MonoBehaviour
{
    // scriptableObject and path
    private static string Path => "Assets/Merge.asset";
    private static TypeOfObjects _objectType;
    [SerializeField] private TypeOfObjects DB;
    // --------------------------
    private void Awake()
    {
        _objectType = DB;
    }
    public static bool MergeObjects(Object obj_1, Object obj_2)
    {
        Debug.Log("ASD");
        if (obj_1.name == obj_2.name)
        {
            if (obj_1.name == _objectType.Chicken_1_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Chicken_2_name, _objectType.Chicken_2_price, _objectType.Chicken_2_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Chicken_2_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Chicken_3_name, _objectType.Chicken_3_price, _objectType.Chicken_3_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Chicken_3_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Chicken_4_name, _objectType.Chicken_4_price, _objectType.Chicken_4_sprite);
                obj_1.TurnOnParticles();
                return true;
            }
            else if (obj_1.name == _objectType.Goose_1_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Goose_2_name, _objectType.Goose_2_price, _objectType.Goose_2_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Goose_2_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Goose_3_name, _objectType.Goose_3_price, _objectType.Goose_3_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Goose_3_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Goose_4_name, _objectType.Goose_4_price, _objectType.Goose_4_sprite);
                obj_1.TurnOnParticles();

                return true;
            }
            else if (obj_1.name == _objectType.Goat_1_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Goat_2_name, _objectType.Goat_2_price, _objectType.Goat_2_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Goat_2_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Goat_3_name, _objectType.Goat_3_price, _objectType.Goat_3_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Goat_3_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Goat_4_name, _objectType.Goat_4_price, _objectType.Goat_4_sprite);
                obj_1.TurnOnParticles();

                return true;
            }
            else if (obj_1.name == _objectType.Ostrich_1_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Ostrich_2_name, _objectType.Ostrich_2_price, _objectType.Ostrich_2_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Ostrich_2_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Ostrich_3_name, _objectType.Ostrich_3_price, _objectType.Ostrich_3_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Ostrich_3_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Ostrich_4_name, _objectType.Ostrich_4_price, _objectType.Ostrich_4_sprite);
                obj_1.TurnOnParticles();

                return true;
            }
            else if (obj_1.name == _objectType.Sheep_1_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Sheep_2_name, _objectType.Sheep_2_price, _objectType.Sheep_2_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Sheep_2_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Sheep_3_name, _objectType.Sheep_3_price, _objectType.Sheep_3_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Sheep_3_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Sheep_4_name, _objectType.Sheep_4_price, _objectType.Sheep_4_sprite);
                obj_1.TurnOnParticles();

                return true;
            }
            else if (obj_1.name == _objectType.Pig_1_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Pig_2_name, _objectType.Pig_2_price, _objectType.Pig_2_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Pig_2_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Pig_3_name, _objectType.Pig_3_price, _objectType.Pig_3_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Pig_3_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Pig_4_name, _objectType.Pig_4_price, _objectType.Pig_4_sprite);
                obj_1.TurnOnParticles();

                return true;
            }
            else if (obj_1.name == _objectType.Cow_1_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Cow_2_name, _objectType.Cow_2_price, _objectType.Cow_2_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Cow_2_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Cow_3_name, _objectType.Cow_3_price, _objectType.Cow_3_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Cow_3_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Cow_4_name, _objectType.Cow_4_price, _objectType.Cow_4_sprite);
                obj_1.TurnOnParticles();

                return true;
            }
            else if (obj_1.name == _objectType.Horse_1_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Horse_2_name, _objectType.Horse_2_price, _objectType.Horse_2_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Horse_2_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Horse_3_name, _objectType.Horse_3_price, _objectType.Horse_3_sprite);
                return true;
            }
            else if (obj_1.name == _objectType.Horse_3_name)
            {
                var parent = obj_2.transform.parent;
                Destroy(obj_2.gameObject);
                obj_1.transform.SetParent(parent);
                obj_1.Initialize(_objectType.Horse_4_name, _objectType.Horse_4_price, _objectType.Horse_4_sprite);
                obj_1.TurnOnParticles();

                return true;
            }
        }
        return false;
    }

}
