using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField] float m_maxHealth;
    [SerializeField] Slider m_healthPointBar;

    float m_currentHealthPoint;
    public float CurrentHealthPoint
    {
        get => m_currentHealthPoint;
        set
        {
            if(m_currentHealthPoint > value)
                GetComponent<DamageFloatingTextController>()?.ApplyDamageText(m_currentHealthPoint - value);

            m_currentHealthPoint = value;

            if(m_healthPointBar != null) m_healthPointBar.value = m_currentHealthPoint / m_maxHealth;

            if (m_currentHealthPoint <= 0)
            {
                Death();
            }
        }
    }

    private void Awake()
    {
        ResetHealthPoint();
    }

    public void ResetHealthPoint()
    {
        CurrentHealthPoint = m_maxHealth;
    }

    public void Death()
    {
        GetComponent<IDeathBehaviour>().Death();
    }
}
