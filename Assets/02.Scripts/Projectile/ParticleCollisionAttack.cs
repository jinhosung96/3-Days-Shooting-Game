using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionAttack : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        HPController targetHP = other.GetComponent<HPController>();
        if (targetHP != null)
        {
            targetHP.CurrentHealthPoint -= PlayerSystem.Instance.AttackDamage;
        }
    }
}
