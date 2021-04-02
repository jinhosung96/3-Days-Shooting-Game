using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : SceneObject<EnemySpawnSystem>
{
    [SerializeField] EnemySpawnController[] m_spawns;
    [SerializeField] GameObject m_spawnEnemy;
    [SerializeField] float m_spawnDelay;
    [SerializeField] float m_spawnDelayErrorRange;
    public EnemySpawnController[] Spawns { get => m_spawns; private set => m_spawns = value; }
    public float SpawnDelay{ get => m_spawnDelay; private set => m_spawnDelay = value; }
    public GameObject SpawnEnemy { get => m_spawnEnemy; private set => m_spawnEnemy = value; }
    public float SpawnDelayErrorRange { get => m_spawnDelayErrorRange; private set => m_spawnDelayErrorRange = value; }
}
