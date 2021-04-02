using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    Animator m_animator;
    [SerializeField] float m_moveSpeed;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        
        Vector3 move = ControllerSystem.Instance.InputDirection * m_moveSpeed * Time.deltaTime;
        transform.Translate(move);
        m_animator.SetFloat("Move", Mathf.Clamp01(move.normalized.magnitude));
        m_animator.SetBool("IsRun", LoopMapSystem.Instance.IsLoop);
    }
}
