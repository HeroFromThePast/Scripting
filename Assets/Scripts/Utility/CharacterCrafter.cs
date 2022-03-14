using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCrafter : MonoBehaviour
{

    public Unit CreateCharacter(UnitTypes.UnitType type)
    {
        GameObject characterObject = new GameObject();
        Unit result = null;
        switch (type)
        {
            case UnitTypes.UnitType.Player:
                result = characterObject.AddComponent<Player>();
                break;
            case UnitTypes.UnitType.Enemy:
                result = characterObject.AddComponent<EnemyScript>();
                break;
            case UnitTypes.UnitType.Support:
                result = characterObject.AddComponent<Obstacle>();
                break;
        }
        if(result != null)
        {
            result.type = type;
            return result;
        }
        else
        {
            return null;
        }

    }

    public Unit CreateCharacter(UnitTypes.UnitType type, string unitName, int level)
    {
        GameObject characterObject = new GameObject();
        Unit result = null; ;
        switch (type)
        {
            case UnitTypes.UnitType.Player:
                result = characterObject.AddComponent<Player>();
                break;
            case UnitTypes.UnitType.Enemy:
                result = characterObject.AddComponent<EnemyScript>();
                break;
            case UnitTypes.UnitType.Support:
                result = characterObject.AddComponent<Obstacle>();
                break;
        }
        if (result != null)
        {
            result.UnitName = unitName;
            result.level = level;
            result.type = type;
            return result;
        }
        else
        {
            return null;
        }

    }
}
