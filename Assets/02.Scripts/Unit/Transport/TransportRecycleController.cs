using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportRecycleController : MonoBehaviour
{
    public void Recycle()
    {
        StartCoroutine(Co_Recycle());
    }

    IEnumerator Co_Recycle()
    {
        TransportSystem.Instance.IsClear = true;
        Vector3 pos = transform.position;
        pos.z = TransportSystem.Instance.StartPosZ;
        GetComponent<HPController>().ResetHealthPoint();
        transform.position = pos;

        while (transform.position.z > TransportSystem.Instance.ParkingPosZ)
        {
            transform.Translate(0f, 0f, -LoopMapSystem.Instance.Speed * Time.deltaTime, Space.World);
            yield return null;
        }
        TransportSystem.Instance.IsClear = false;
    }
}
