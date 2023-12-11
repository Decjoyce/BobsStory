using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Classmate Type", menuName = "Classmates")]
public class ClassmateType : ScriptableObject
{
    public string classmateType;
    public GameObject[] modelsStanding;
    public GameObject[] modelsSitting;
    public int standing;
    public TextAsset inkJSONFile;

    public virtual void ChangeModels(Transform[] modelPositions, bool sitting)
    {
        foreach(Transform pos in modelPositions)
        {
            if (sitting)
                Instantiate(modelsSitting[Random.Range(0, modelsSitting.Length)], pos);
            else
                Instantiate(modelsStanding[Random.Range(0, modelsStanding.Length)], pos);
        }
    }

}
