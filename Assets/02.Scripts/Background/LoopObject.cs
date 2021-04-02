using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(LoopMapSystem.Instance.IsLoop)
            transform.Translate(0f, 0f, -LoopMapSystem.Instance.Speed * Time.deltaTime, Space.World);
    }
}
