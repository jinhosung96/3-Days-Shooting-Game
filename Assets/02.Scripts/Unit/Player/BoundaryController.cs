using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    [SerializeField] float m_padding;

    private void Update()
    {
        Boundary();
    }

    private void Boundary()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f + m_padding) pos.x = 0f + m_padding;
        if (pos.x > 1f - m_padding) pos.x = 1f - m_padding;
        if (pos.y < 0f + m_padding) pos.y = 0f + m_padding;
        if (pos.y > 0.5f - m_padding) pos.y = 0.5f - m_padding;

        Vector3 movePos = Camera.main.ViewportToWorldPoint(pos);
        movePos.y = 0;
        transform.position = movePos;
    }
}
