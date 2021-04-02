using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace JHS
{
    public class CollisionHit : MonoBehaviour, ICollisionFunction
    {
        #region 변수

        public float hitOffset = 0f;
        public bool UseFirePointRotation;
        public Vector3 rotationOffset = new Vector3(0, 0, 0);
        public GameObject hit;
        public GameObject flash;
        public GameObject[] Detached;

        #endregion

        #region 유니티 생명주기

        void Start()
        {
            if (flash != null)
            {
                var flashInstance = Instantiate(flash, transform.position, Quaternion.identity);
                flashInstance.transform.forward = gameObject.transform.forward;
                var flashPs = flashInstance.GetComponent<ParticleSystem>();
                if (flashPs != null)
                {
                    Destroy(flashInstance, flashPs.main.duration);
                }
                else
                {
                    var flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(flashInstance, flashPsParts.main.duration);
                }
            }
        }

        #endregion

        #region 콜백 함수

        //https ://docs.unity3d.com/ScriptReference/Rigidbody.OnCollisionEnter.html
        public void OnCollisionEnterFunction(Collision _collision, Transform _transform)
        {
            //Lock all axes movement and rotation
            _transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            _transform.GetComponent<ProjectileMover>().Speed = 0;

            ContactPoint contact = _collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point + contact.normal * hitOffset;

            if (hit != null)
            {
                var hitInstance = Instantiate(hit, pos, rot);
                if (UseFirePointRotation) { hitInstance.transform.rotation = _transform.rotation * Quaternion.Euler(0, 180f, 0); }
                else if (rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(rotationOffset); }
                else { hitInstance.transform.LookAt(contact.point + contact.normal); }

                var hitPs = hitInstance.GetComponent<ParticleSystem>();
                if (hitPs != null)
                {
                    Destroy(hitInstance, hitPs.main.duration);
                }
                else
                {
                    var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(hitInstance, hitPsParts.main.duration);
                }
            }
            foreach (var detachedPrefab in Detached)
            {
                if (detachedPrefab != null)
                {
                    detachedPrefab.transform.parent = null;
                }
            }
        }

        #endregion
    } 
}
