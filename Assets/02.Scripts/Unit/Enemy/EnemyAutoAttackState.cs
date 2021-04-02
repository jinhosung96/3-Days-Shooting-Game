using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoAttackState : State
{
    Animator m_animator;
    [SerializeField] float m_attackSpeed;
    [SerializeField] GameObject m_projectile;
    [SerializeField] Transform m_shootPoint;

    protected override void OnAwake()
    {
        m_animator = GetComponent<Animator>();
    }

    public override void OnEnter()
    {
        m_animator.SetTrigger("DoIdle");
        StartCoroutine(Co_AutoAttack());
    }

    public override void OnExit()
    {
        StopAllCoroutines();
    }

    IEnumerator Co_AutoAttack()
    {
        while (true)
        {
            LookAtPlayer();
            Shoot();

            yield return new WaitForSeconds(m_attackSpeed);
        }
    }

    void LookAtPlayer()
    {
        Vector3 position = PlayerSystem.Instance.PlayerTr.position;
        position.x = PlayerSystem.Instance.PlayerTr.position.x - 2;
        transform.rotation = Quaternion.LookRotation(position - transform.position);
    }

    void Shoot()
    {
        m_animator.SetTrigger("DoShoot");
    }

    void OnShoot()
    {
        GameObject projectile = Instantiate(m_projectile);
        projectile.transform.position = m_shootPoint.position;
        projectile.transform.forward = m_shootPoint.forward;
    }
}
