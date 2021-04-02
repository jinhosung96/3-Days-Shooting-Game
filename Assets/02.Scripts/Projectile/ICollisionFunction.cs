using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public interface ICollisionFunction
{
    void OnCollisionEnterFunction(Collision _collision, Transform _transform);
}
