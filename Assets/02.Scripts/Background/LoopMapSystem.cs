using JHS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMapSystem : SceneObject<LoopMapSystem>
{
    [SerializeField] LoopTileController[] m_tiles;
    [SerializeField] float m_speed;
    [SerializeField] float m_startPosZ;
    [SerializeField] float m_endPosZ;
    [SerializeField] bool m_isLoop;

    public float Speed { get => m_speed; private set => m_speed = value; }
    public float StartPosZ { get => m_startPosZ; private set => m_startPosZ = value; }
    public float EndPosZ { get => m_endPosZ; private set => m_endPosZ = value; }
    public bool IsLoop { get => m_isLoop; set => m_isLoop = value; }
}
