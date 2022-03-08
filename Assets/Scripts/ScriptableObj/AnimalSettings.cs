using UnityEngine;

[CreateAssetMenu(fileName = "Animal_Settings", menuName = "ScriptableObjects/Animal_Settings", order = 1)]
public class AnimalSettings : ScriptableObject
{
    public float walking_speed;
    public float run_speed;
    public float min_Time_ToStay, max_Time_To_Stay;
}
