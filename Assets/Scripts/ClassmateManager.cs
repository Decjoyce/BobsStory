using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClassmateManager : MonoBehaviour
{
    [SerializeField] Classmates[] classmates;
    [SerializeField] ClassmateType[] classmatesTypes;
    private List<ClassmateType> availableClassmateTypes = new List<ClassmateType>();

    private void Awake()
    {
        SetUpClassmates();
    }

    public void SetUpClassmates()
    {
        availableClassmateTypes = classmatesTypes.ToList();
        foreach (Classmates mates in classmates)
        {
            int ranType = Random.Range(0, availableClassmateTypes.Count() - 1);
            mates.ChangeType(availableClassmateTypes[ranType]);
            availableClassmateTypes.Remove(availableClassmateTypes[ranType]);
        }
    }

}
