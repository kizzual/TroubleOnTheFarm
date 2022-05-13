using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TypeOfObjects))]
public class MergeEditor : Editor
{
    SerializedProperty type;

    bool ShowFirsGrade = false;
    string status_1 = "First grade ";
    bool ShowSecondGrade = false;
    string status_2 = "Second grade ";
    bool ShowThirddGrade = false;
    string status_3 = "Third grade ";
    #region Name
    SerializedProperty Chicken_1_name;
    SerializedProperty Chicken_2_name;
    SerializedProperty Chicken_3_name;
    SerializedProperty Chicken_4_name;
    SerializedProperty Goose_1_name;
    SerializedProperty Goose_2_name;
    SerializedProperty Goose_3_name;
    SerializedProperty Goose_4_name;
    SerializedProperty Goat_1_name;
    SerializedProperty Goat_2_name;
    SerializedProperty Goat_3_name;
    SerializedProperty Goat_4_name;
    SerializedProperty Ostrich_1_name;
    SerializedProperty Ostrich_2_name;
    SerializedProperty Ostrich_3_name;
    SerializedProperty Ostrich_4_name;
    SerializedProperty Sheep_1_name;
    SerializedProperty Sheep_2_name;
    SerializedProperty Sheep_3_name;
    SerializedProperty Sheep_4_name;
    SerializedProperty Pig_1_name;
    SerializedProperty Pig_2_name;
    SerializedProperty Pig_3_name;
    SerializedProperty Pig_4_name;
    SerializedProperty Cow_1_name;
    SerializedProperty Cow_2_name;
    SerializedProperty Cow_3_name;
    SerializedProperty Cow_4_name;
    SerializedProperty Horse_1_name;
    SerializedProperty Horse_2_name;
    SerializedProperty Horse_3_name;
    SerializedProperty Horse_4_name;
    SerializedProperty Chicken_1_price;
    SerializedProperty Chicken_2_price;
    SerializedProperty Chicken_3_price;
    SerializedProperty Chicken_4_price;
    SerializedProperty Goose_1_price;
    SerializedProperty Goose_2_price;
    SerializedProperty Goose_3_price;
    SerializedProperty Goose_4_price;
    SerializedProperty Goat_1_price;
    SerializedProperty Goat_2_price;
    SerializedProperty Goat_3_price;
    SerializedProperty Goat_4_price;
    SerializedProperty Ostrich_1_price;
    SerializedProperty Ostrich_2_price;
    SerializedProperty Ostrich_3_price;
    SerializedProperty Ostrich_4_price;
    SerializedProperty Sheep_1_price;
    SerializedProperty Sheep_2_price;
    SerializedProperty Sheep_3_price;
    SerializedProperty Sheep_4_price;
    SerializedProperty Pig_1_price;
    SerializedProperty Pig_2_price;
    SerializedProperty Pig_3_price;
    SerializedProperty Pig_4_price;
    SerializedProperty Cow_1_price;
    SerializedProperty Cow_2_price;
    SerializedProperty Cow_3_price;
    SerializedProperty Cow_4_price;
    SerializedProperty Horse_1_price;
    SerializedProperty Horse_2_price;
    SerializedProperty Horse_3_price;
    SerializedProperty Horse_4_price;
    SerializedProperty Chicken_1_sprite;
    SerializedProperty Chicken_2_sprite;
    SerializedProperty Chicken_3_sprite;
    SerializedProperty Chicken_4_sprite;
    SerializedProperty Goose_1_sprite;
    SerializedProperty Goose_2_sprite;
    SerializedProperty Goose_3_sprite;
    SerializedProperty Goose_4_sprite;
    SerializedProperty Goat_1_sprite;
    SerializedProperty Goat_2_sprite;
    SerializedProperty Goat_3_sprite;
    SerializedProperty Goat_4_sprite;
    SerializedProperty Ostrich_1_sprite;
    SerializedProperty Ostrich_2_sprite;
    SerializedProperty Ostrich_3_sprite;
    SerializedProperty Ostrich_4_sprite;
    SerializedProperty Sheep_1_sprite;
    SerializedProperty Sheep_2_sprite;
    SerializedProperty Sheep_3_sprite;
    SerializedProperty Sheep_4_sprite;
    SerializedProperty Pig_1_sprite;
    SerializedProperty Pig_2_sprite;
    SerializedProperty Pig_3_sprite;
    SerializedProperty Pig_4_sprite;
    SerializedProperty Cow_1_sprite;
    SerializedProperty Cow_2_sprite;
    SerializedProperty Cow_3_sprite;
    SerializedProperty Cow_4_sprite;
    SerializedProperty Horse_1_sprite;
    SerializedProperty Horse_2_sprite;
    SerializedProperty Horse_3_sprite;
    SerializedProperty Horse_4_sprite;
    #endregion
    void OnEnable()
    {
        type = serializedObject.FindProperty("Type");
        Chicken_1_name = serializedObject.FindProperty("Chicken_1_name");
        Chicken_2_name = serializedObject.FindProperty("Chicken_2_name");
        Chicken_3_name = serializedObject.FindProperty("Chicken_3_name");
        Chicken_4_name = serializedObject.FindProperty("Chicken_4_name");
        Goose_1_name = serializedObject.FindProperty("Goose_1_name");
        Goose_2_name = serializedObject.FindProperty("Goose_2_name");
        Goose_3_name = serializedObject.FindProperty("Goose_3_name");
        Goose_4_name = serializedObject.FindProperty("Goose_4_name");
        Goat_1_name = serializedObject.FindProperty("Goat_1_name");
        Goat_2_name = serializedObject.FindProperty("Goat_2_name");
        Goat_3_name = serializedObject.FindProperty("Goat_3_name");
        Goat_4_name = serializedObject.FindProperty("Goat_4_name");
        Ostrich_1_name = serializedObject.FindProperty("Ostrich_1_name");
        Ostrich_2_name = serializedObject.FindProperty("Ostrich_2_name");
        Ostrich_3_name = serializedObject.FindProperty("Ostrich_3_name");
        Ostrich_4_name = serializedObject.FindProperty("Ostrich_4_name");
        Sheep_1_name = serializedObject.FindProperty("Sheep_1_name");
        Sheep_2_name = serializedObject.FindProperty("Sheep_2_name");
        Sheep_3_name = serializedObject.FindProperty("Sheep_3_name");
        Sheep_4_name = serializedObject.FindProperty("Sheep_4_name");
        Pig_1_name = serializedObject.FindProperty("Pig_1_name");
        Pig_2_name = serializedObject.FindProperty("Pig_2_name");
        Pig_3_name = serializedObject.FindProperty("Pig_3_name");
        Pig_4_name = serializedObject.FindProperty("Pig_4_name");
        Cow_1_name = serializedObject.FindProperty("Cow_1_name");
        Cow_2_name = serializedObject.FindProperty("Cow_2_name");
        Cow_3_name = serializedObject.FindProperty("Cow_3_name");
        Cow_4_name = serializedObject.FindProperty("Cow_4_name");
        Horse_1_name = serializedObject.FindProperty("Horse_1_name");
        Horse_2_name = serializedObject.FindProperty("Horse_2_name");
        Horse_3_name = serializedObject.FindProperty("Horse_3_name");
        Horse_4_name = serializedObject.FindProperty("Horse_4_name");
        Chicken_1_price = serializedObject.FindProperty("Chicken_1_price");
        Chicken_2_price = serializedObject.FindProperty("Chicken_2_price");
        Chicken_3_price = serializedObject.FindProperty("Chicken_3_price");
        Chicken_4_price = serializedObject.FindProperty("Chicken_4_price");
        Goose_1_price = serializedObject.FindProperty("Goose_1_price");
        Goose_2_price = serializedObject.FindProperty("Goose_2_price");
        Goose_3_price = serializedObject.FindProperty("Goose_3_price");
        Goose_4_price = serializedObject.FindProperty("Goose_4_price");
        Goat_1_price = serializedObject.FindProperty("Goat_1_price");
        Goat_2_price = serializedObject.FindProperty("Goat_2_price");
        Goat_3_price = serializedObject.FindProperty("Goat_3_price");
        Goat_4_price = serializedObject.FindProperty("Goat_4_price");
        Ostrich_1_price = serializedObject.FindProperty("Ostrich_1_price");
        Ostrich_2_price = serializedObject.FindProperty("Ostrich_2_price");
        Ostrich_3_price = serializedObject.FindProperty("Ostrich_3_price");
        Ostrich_4_price = serializedObject.FindProperty("Ostrich_4_price");
        Sheep_1_price = serializedObject.FindProperty("Sheep_1_price");
        Sheep_2_price = serializedObject.FindProperty("Sheep_2_price");
        Sheep_3_price = serializedObject.FindProperty("Sheep_3_price");
        Sheep_4_price = serializedObject.FindProperty("Sheep_4_price");
        Pig_1_price = serializedObject.FindProperty("Pig_1_price");
        Pig_2_price = serializedObject.FindProperty("Pig_2_price");
        Pig_3_price = serializedObject.FindProperty("Pig_3_price");
        Pig_4_price = serializedObject.FindProperty("Pig_4_price");
        Cow_1_price = serializedObject.FindProperty("Cow_1_price");
        Cow_2_price = serializedObject.FindProperty("Cow_2_price"); 
        Cow_3_price = serializedObject.FindProperty("Cow_3_price"); 
        Cow_4_price = serializedObject.FindProperty("Cow_4_price");
        Horse_1_price = serializedObject.FindProperty("Horse_1_price");
        Horse_2_price = serializedObject.FindProperty("Horse_2_price");
        Horse_3_price = serializedObject.FindProperty("Horse_3_price");
        Horse_4_price = serializedObject.FindProperty("Horse_4_price");
        Chicken_1_sprite = serializedObject.FindProperty("Chicken_1_sprite");
        Chicken_2_sprite = serializedObject.FindProperty("Chicken_2_sprite");
        Chicken_3_sprite = serializedObject.FindProperty("Chicken_3_sprite");
        Chicken_4_sprite = serializedObject.FindProperty("Chicken_4_sprite");
        Goose_1_sprite = serializedObject.FindProperty("Goose_1_sprite");
        Goose_2_sprite = serializedObject.FindProperty("Goose_2_sprite");
        Goose_3_sprite = serializedObject.FindProperty("Goose_3_sprite");
        Goose_4_sprite = serializedObject.FindProperty("Goose_4_sprite");
        Goat_1_sprite = serializedObject.FindProperty("Goat_1_sprite");
        Goat_2_sprite = serializedObject.FindProperty("Goat_2_sprite");
        Goat_3_sprite = serializedObject.FindProperty("Goat_3_sprite");
        Goat_4_sprite = serializedObject.FindProperty("Goat_4_sprite");
        Ostrich_1_sprite = serializedObject.FindProperty("Ostrich_1_sprite");
        Ostrich_2_sprite = serializedObject.FindProperty("Ostrich_2_sprite");
        Ostrich_3_sprite = serializedObject.FindProperty("Ostrich_3_sprite");
        Ostrich_4_sprite = serializedObject.FindProperty("Ostrich_4_sprite");
        Sheep_1_sprite = serializedObject.FindProperty("Sheep_1_sprite");
        Sheep_2_sprite = serializedObject.FindProperty("Sheep_2_sprite");
        Sheep_3_sprite = serializedObject.FindProperty("Sheep_3_sprite");
        Sheep_4_sprite = serializedObject.FindProperty("Sheep_4_sprite");
        Pig_1_sprite = serializedObject.FindProperty("Pig_1_sprite");
        Pig_2_sprite = serializedObject.FindProperty("Pig_2_sprite");
        Pig_3_sprite = serializedObject.FindProperty("Pig_3_sprite");
        Pig_4_sprite = serializedObject.FindProperty("Pig_4_sprite");
        Cow_1_sprite = serializedObject.FindProperty("Cow_1_sprite");
        Cow_2_sprite = serializedObject.FindProperty("Cow_2_sprite");
        Cow_3_sprite = serializedObject.FindProperty("Cow_3_sprite");
        Cow_4_sprite = serializedObject.FindProperty("Cow_4_sprite");
        Horse_1_sprite = serializedObject.FindProperty("Horse_1_sprite");
        Horse_2_sprite = serializedObject.FindProperty("Horse_2_sprite");
        Horse_3_sprite = serializedObject.FindProperty("Horse_3_sprite");
        Horse_4_sprite = serializedObject.FindProperty("Horse_4_sprite");
       
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(type);
        if (type.enumValueIndex == (int)Type.Chicken)
        {
            EditorGUILayout.PropertyField(Chicken_1_name);
            EditorGUILayout.PropertyField(Chicken_1_price);
            EditorGUILayout.PropertyField(Chicken_1_sprite);
            EditorGUILayout.Space();
            ShowFirsGrade = EditorGUILayout.Foldout(ShowFirsGrade, status_1);
            EditorGUILayout.Space();
            if (ShowFirsGrade)
            {
                EditorGUILayout.PropertyField(Chicken_2_name);
                EditorGUILayout.PropertyField(Chicken_2_price);
                EditorGUILayout.PropertyField(Chicken_2_sprite);
            }
            ShowSecondGrade = EditorGUILayout.Foldout(ShowSecondGrade, status_2);
            EditorGUILayout.Space();
            if (ShowSecondGrade)
            {
                EditorGUILayout.PropertyField(Chicken_3_name);
                EditorGUILayout.PropertyField(Chicken_3_price);
                EditorGUILayout.PropertyField(Chicken_3_sprite);
            }
            ShowThirddGrade = EditorGUILayout.Foldout(ShowThirddGrade, status_3);
            EditorGUILayout.Space();
            if (ShowThirddGrade)
            {
                EditorGUILayout.PropertyField(Chicken_4_name);
                EditorGUILayout.PropertyField(Chicken_4_price);
                EditorGUILayout.PropertyField(Chicken_4_sprite);
            }
        }
        if (type.enumValueIndex == (int)Type.Goose)
        {
            EditorGUILayout.PropertyField(Goose_1_name);
            EditorGUILayout.PropertyField(Goose_1_price);
            EditorGUILayout.PropertyField(Goose_1_sprite);
            EditorGUILayout.Space();
            ShowFirsGrade = EditorGUILayout.Foldout(ShowFirsGrade, status_1);
            EditorGUILayout.Space();
            if (ShowFirsGrade)
            {
                EditorGUILayout.PropertyField(Goose_2_name);
                EditorGUILayout.PropertyField(Goose_2_price);
                EditorGUILayout.PropertyField(Goose_2_sprite);
            }
            ShowSecondGrade = EditorGUILayout.Foldout(ShowSecondGrade, status_2);
            EditorGUILayout.Space();
            if (ShowSecondGrade)
            {
                EditorGUILayout.PropertyField(Goose_3_name);
                EditorGUILayout.PropertyField(Goose_3_price);
                EditorGUILayout.PropertyField(Goose_3_sprite);
            }
            ShowThirddGrade = EditorGUILayout.Foldout(ShowThirddGrade, status_3);
            EditorGUILayout.Space();
            if (ShowThirddGrade)
            {
                EditorGUILayout.PropertyField(Goose_4_name);
                EditorGUILayout.PropertyField(Goose_4_price);
                EditorGUILayout.PropertyField(Goose_4_sprite);
            }
        }
        if (type.enumValueIndex == (int)Type.Goat)
        {
            EditorGUILayout.PropertyField(Goat_1_name);
            EditorGUILayout.PropertyField(Goat_1_price);
            EditorGUILayout.PropertyField(Goat_1_sprite);
            EditorGUILayout.Space();
            ShowFirsGrade = EditorGUILayout.Foldout(ShowFirsGrade, status_1);
            EditorGUILayout.Space();
            if (ShowFirsGrade)
            {
                EditorGUILayout.PropertyField(Goat_2_name);
                EditorGUILayout.PropertyField(Goat_2_price);
                EditorGUILayout.PropertyField(Goat_2_sprite);
            }
            ShowSecondGrade = EditorGUILayout.Foldout(ShowSecondGrade, status_2);
            EditorGUILayout.Space();
            if (ShowSecondGrade)
            {
                EditorGUILayout.PropertyField(Goat_3_name);
                EditorGUILayout.PropertyField(Goat_3_price);
                EditorGUILayout.PropertyField(Goat_3_sprite);
            }
            ShowThirddGrade = EditorGUILayout.Foldout(ShowThirddGrade, status_3);
            EditorGUILayout.Space();
            if (ShowThirddGrade)
            {
                EditorGUILayout.PropertyField(Goat_4_name);
                EditorGUILayout.PropertyField(Goat_4_price);
                EditorGUILayout.PropertyField(Goat_4_sprite);
            }
        }
        if (type.enumValueIndex == (int)Type.Ostrich)
        {
            EditorGUILayout.PropertyField(Ostrich_1_name);
            EditorGUILayout.PropertyField(Ostrich_1_price);
            EditorGUILayout.PropertyField(Ostrich_1_sprite);
            EditorGUILayout.Space();
            ShowFirsGrade = EditorGUILayout.Foldout(ShowFirsGrade, status_1);
            EditorGUILayout.Space();
            if (ShowFirsGrade)
            {
                EditorGUILayout.PropertyField(Ostrich_2_name);
                EditorGUILayout.PropertyField(Ostrich_2_price);
                EditorGUILayout.PropertyField(Ostrich_2_sprite);
            }
            ShowSecondGrade = EditorGUILayout.Foldout(ShowSecondGrade, status_2);
            EditorGUILayout.Space();
            if (ShowSecondGrade)
            {
                EditorGUILayout.PropertyField(Ostrich_3_name);
                EditorGUILayout.PropertyField(Ostrich_3_price);
                EditorGUILayout.PropertyField(Ostrich_3_sprite);
            }
            ShowThirddGrade = EditorGUILayout.Foldout(ShowThirddGrade, status_3);
            EditorGUILayout.Space();
            if (ShowThirddGrade)
            {
                EditorGUILayout.PropertyField(Ostrich_4_name);
                EditorGUILayout.PropertyField(Ostrich_4_price);
                EditorGUILayout.PropertyField(Ostrich_4_sprite);
            }

        }
        if (type.enumValueIndex == (int)Type.Sheep)
        {
            EditorGUILayout.PropertyField(Sheep_1_name);
            EditorGUILayout.PropertyField(Sheep_1_price);
            EditorGUILayout.PropertyField(Sheep_1_sprite);
            EditorGUILayout.Space();
            ShowFirsGrade = EditorGUILayout.Foldout(ShowFirsGrade, status_1);
            EditorGUILayout.Space();
            if (ShowFirsGrade)
            {
                EditorGUILayout.PropertyField(Sheep_2_name);
                EditorGUILayout.PropertyField(Sheep_2_price);
                EditorGUILayout.PropertyField(Sheep_2_sprite);
            }
            ShowSecondGrade = EditorGUILayout.Foldout(ShowSecondGrade, status_2);
            EditorGUILayout.Space();
            if (ShowSecondGrade)
            {
                EditorGUILayout.PropertyField(Sheep_3_name);
                EditorGUILayout.PropertyField(Sheep_3_price);
                EditorGUILayout.PropertyField(Sheep_3_sprite);
            }
            ShowThirddGrade = EditorGUILayout.Foldout(ShowThirddGrade, status_3);
            EditorGUILayout.Space();
            if (ShowThirddGrade)
            {
                EditorGUILayout.PropertyField(Sheep_4_name);
                EditorGUILayout.PropertyField(Sheep_4_price);
                EditorGUILayout.PropertyField(Sheep_4_sprite);
            }

        }
        if (type.enumValueIndex == (int)Type.Pig)
        {
            EditorGUILayout.PropertyField(Pig_1_name);
            EditorGUILayout.PropertyField(Pig_1_price);
            EditorGUILayout.PropertyField(Pig_1_sprite);
            EditorGUILayout.Space();
            ShowFirsGrade = EditorGUILayout.Foldout(ShowFirsGrade, status_1);
            EditorGUILayout.Space();
            if (ShowFirsGrade)
            {
                EditorGUILayout.PropertyField(Pig_2_name);
                EditorGUILayout.PropertyField(Pig_2_price);
                EditorGUILayout.PropertyField(Pig_2_sprite);
            }
            ShowSecondGrade = EditorGUILayout.Foldout(ShowSecondGrade, status_2);
            EditorGUILayout.Space();
            if (ShowSecondGrade)
            {
                EditorGUILayout.PropertyField(Pig_3_name);
                EditorGUILayout.PropertyField(Pig_3_price);
                EditorGUILayout.PropertyField(Pig_3_sprite);
            }
            ShowThirddGrade = EditorGUILayout.Foldout(ShowThirddGrade, status_3);
            EditorGUILayout.Space();
            if (ShowThirddGrade)
            {
                EditorGUILayout.PropertyField(Pig_4_name);
                EditorGUILayout.PropertyField(Pig_4_price);
                EditorGUILayout.PropertyField(Pig_4_sprite);
            }
        }
        if (type.enumValueIndex == (int)Type.Cow)
        {
            EditorGUILayout.PropertyField(Cow_1_name);
            EditorGUILayout.PropertyField(Cow_1_price);
            EditorGUILayout.PropertyField(Cow_1_sprite);
            EditorGUILayout.Space();
            ShowFirsGrade = EditorGUILayout.Foldout(ShowFirsGrade, status_1);
            EditorGUILayout.Space();
            if (ShowFirsGrade)
            {
                EditorGUILayout.PropertyField(Cow_2_name);
                EditorGUILayout.PropertyField(Cow_2_price);
                EditorGUILayout.PropertyField(Cow_2_sprite);
            }
            ShowSecondGrade = EditorGUILayout.Foldout(ShowSecondGrade, status_2);
            EditorGUILayout.Space();
            if (ShowSecondGrade)
            {
                EditorGUILayout.PropertyField(Cow_3_name);
                EditorGUILayout.PropertyField(Cow_3_price);
                EditorGUILayout.PropertyField(Cow_3_sprite);
            }
            ShowThirddGrade = EditorGUILayout.Foldout(ShowThirddGrade, status_3);
            EditorGUILayout.Space();
            if (ShowThirddGrade)
            {
                EditorGUILayout.PropertyField(Cow_4_name);
                EditorGUILayout.PropertyField(Cow_4_price);
                EditorGUILayout.PropertyField(Cow_4_sprite);
            }
        }
        if (type.enumValueIndex == (int)Type.Horse)
        {
            EditorGUILayout.PropertyField(Horse_1_name);
            EditorGUILayout.PropertyField(Horse_1_price);
            EditorGUILayout.PropertyField(Horse_1_sprite);
            EditorGUILayout.Space();
            ShowFirsGrade = EditorGUILayout.Foldout(ShowFirsGrade, status_1);
            EditorGUILayout.Space();
            if (ShowFirsGrade)
            {
                EditorGUILayout.PropertyField(Horse_2_name);
                EditorGUILayout.PropertyField(Horse_2_price);
                EditorGUILayout.PropertyField(Horse_2_sprite);
            }
            ShowSecondGrade = EditorGUILayout.Foldout(ShowSecondGrade, status_2);
            EditorGUILayout.Space();
            if (ShowSecondGrade)
            {
                EditorGUILayout.PropertyField(Horse_3_name);
                EditorGUILayout.PropertyField(Horse_3_price);
                EditorGUILayout.PropertyField(Horse_3_sprite);
            }
            ShowThirddGrade = EditorGUILayout.Foldout(ShowThirddGrade, status_3);
            EditorGUILayout.Space();
            if (ShowThirddGrade)
            {
                EditorGUILayout.PropertyField(Horse_4_name);
                EditorGUILayout.PropertyField(Horse_4_price);
                EditorGUILayout.PropertyField(Horse_4_sprite);
            }
        }



        serializedObject.ApplyModifiedProperties();
    }
}
