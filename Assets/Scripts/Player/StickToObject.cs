using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToObject : MonoBehaviour
{
    [SerializeField] float sphereRadius = 1.5f;
    [SerializeField] int layermask = 8;

    SphereCollider sC;
    
    private Movement m;

    private void Awake()
    {
        sC = GetComponent<SphereCollider>();
        m = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        sC.radius = sphereRadius;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == layermask)
        {
            m.SetStickability(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == layermask)
        {
            m.SetStickability(false);
            m.ActivateStickToObject(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }
}
