using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour, IDeathBehaviour
{
    [SerializeField] GameObject m_deathParticle;
    [SerializeField] float m_offsetY;
    [SerializeField] float m_offsetScale;
    public void Death()
    {
        GameObject deathParticle = Instantiate(m_deathParticle);
        Vector3 position = transform.position;
        position.y = transform.position.y + m_offsetY;
        deathParticle.transform.position = position;
        deathParticle.transform.localScale *= m_offsetScale;

        Destroy(this.gameObject);
    }
}
