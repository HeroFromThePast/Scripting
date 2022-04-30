using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour, IFactory
{
    [SerializeField]
    private GameObject template;

    public virtual GameObject GetNewEntity(string name, int level, UnitTypes.UnitType type)
    {
        GameObject instance = Instantiate(template);
        Unit unitScript = template.GetComponent<Unit>();
        unitScript.name = name;
        unitScript.level = level;
        unitScript.type = type;
        return instance;
    }
}
