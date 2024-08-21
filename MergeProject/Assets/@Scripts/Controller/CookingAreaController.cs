using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CookingAreaController : StuffController
{
    protected abstract void CreateFood(Vector3 _pos);
}
