using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTileController : MonoBehaviour
{
    private void Update()
    {
        MoveLoad();
    }

    void MoveLoad()
    {
        if (!LoopMapSystem.Instance.IsLoop) return;
        transform.Translate(0f, 0f, -LoopMapSystem.Instance.Speed * Time.deltaTime, Space.World);
        Loop();
    }

    void Loop()
    {
        if (transform.position.z <= LoopMapSystem.Instance.EndPosZ)
        {
            Vector3 pos = transform.position;
            pos.z += LoopMapSystem.Instance.StartPosZ - LoopMapSystem.Instance.EndPosZ;
            transform.position = pos;
        }
    }
}
