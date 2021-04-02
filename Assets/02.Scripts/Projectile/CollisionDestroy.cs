using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour, ICollisionFunction
{
    public void OnCollisionEnterFunction(Collision _collision, Transform _transform)
    {
        Destroy(_transform.gameObject);
    }
}
