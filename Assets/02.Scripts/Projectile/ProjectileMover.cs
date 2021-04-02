using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    public class ProjectileMover : MonoBehaviour
    {
        Rigidbody m_rigidbody;

        [SerializeField] float speed = 15f;

        public float Speed { get => speed; set => speed = value; }

        private void Start()
        {
            m_rigidbody = transform.GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            Destroy(gameObject, 5);
            if (Speed != 0)
            {
                m_rigidbody.velocity = transform.forward * Speed;      
            }
        }
    } 
}
