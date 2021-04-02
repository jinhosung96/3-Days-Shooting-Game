using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveState : State
{
    NavMeshAgent m_agent;
    Transform m_targetPos;

    [SerializeField] State m_nextState;

    public Transform TargetPos { get => m_targetPos; set => m_targetPos = value; }

    protected override void OnAwake()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    protected override void OnUpdate()
    {
        Move();
    }

    public override void OnExit()
    {
        transform.position = TargetPos.position;
        m_agent.ResetPath();
        m_agent.enabled = false;
    }

    public void Move()
    {
        if(Vector3.Distance(TargetPos.position, transform.position) > 0.1f)
        {
            m_agent.SetDestination(TargetPos.position);
        }
        else
        {
            m_machine.SetState(m_nextState);
        }
    }
}
