using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : SceneObject<PlayerSystem>
{
    public GameObject m_player;

    [SerializeField] float m_attackDamage;

    public Transform PlayerTr { get => m_player.transform; }
    public float AttackDamage { get => m_attackDamage; }
}
