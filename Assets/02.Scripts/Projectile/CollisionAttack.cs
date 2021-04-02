using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAttack : MonoBehaviour, ICollisionFunction
{
    [SerializeField] float m_attackDamage;
    public float AttackDamage { get => m_attackDamage; set => m_attackDamage = value; }

    public void OnCollisionEnterFunction(Collision _collision, Transform _transform)
    {
        if (_collision.transform.GetComponent<HPController>() != null)
            _collision.transform.GetComponent<HPController>().CurrentHealthPoint -= AttackDamage;
    }
}
