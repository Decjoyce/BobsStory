using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Classmate Type", menuName = "Classmates")]
public class ClassmateType : ScriptableObject
{
    public string classmateType;
    public GameObject[] models;
    public int standing;
    public TextAsset inkJSONFile;

    public virtual void ChangeModels(Transform[] modelPositions)
    {
        foreach(Transform pos in modelPositions)
        {
            Instantiate(models[Random.Range(0, models.Length)], pos);
        }
    }

}
