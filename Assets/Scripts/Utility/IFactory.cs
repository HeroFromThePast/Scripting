using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory 
{
     GameObject GetNewEntity(string name, int level, UnitTypes.UnitType type);
}
