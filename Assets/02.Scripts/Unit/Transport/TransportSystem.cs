using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportSystem : SceneObject<TransportSystem>
{
    [SerializeField] bool m_isClear;

    [Header("수송선 재활용")]
    [SerializeField] TransportRecycleController m_transport;
    [SerializeField] float m_startPosZ;
    [SerializeField] float m_parkingPosZ;

    public float StartPosZ { get => m_startPosZ; private set => m_startPosZ = value; }
    public float ParkingPosZ { get => m_parkingPosZ; private set => m_parkingPosZ = value; }

    public bool IsClear
    {
        get => m_isClear;
        set
        {
            m_isClear = value;


            if (value)
            {
                LoopMapSystem.Instance.IsLoop = true;
                for (int i = 0; i < EnemySpawnSystem.Instance.Spawns.Length; i++)
                {
                    EnemySpawnSystem.Instance.Spawns[i].StopSpawn();
                    EnemySystem.Instance.Cancellation();
                }
            }
            else
            {
                LoopMapSystem.Instance.IsLoop = false;
                for (int i = 0; i < EnemySpawnSystem.Instance.Spawns.Length; i++)
                {
                    EnemySpawnSystem.Instance.Spawns[i].StartSpawn();
                }
            }
        }
    }

    private void Start()
    {
        Recycle();
    }

    [ContextMenu("테스트")]
    public void Recycle()
    {
        m_transport.Recycle();
    }
}
