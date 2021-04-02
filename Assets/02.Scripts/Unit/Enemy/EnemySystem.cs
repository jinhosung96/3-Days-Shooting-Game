using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : SceneObject<EnemySystem>
{
    [SerializeField] HPController[] m_enemys;

    public HPController[] Enemys { get => m_enemys;}

    public void Cancellation()
    {
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i] == null) continue;

            Enemys[i].Death();
            Enemys[i] = null;
        }
    }
}
