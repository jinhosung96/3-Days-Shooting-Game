using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] GameObject[] m_collisionFunctions;

    private void OnCollisionEnter(Collision _collision)
    {
        for (int i = 0; i < m_collisionFunctions.Length; i++)
        {
            m_collisionFunctions[i].GetComponent<ICollisionFunction>().OnCollisionEnterFunction(_collision, transform);
        }    
    }
}
