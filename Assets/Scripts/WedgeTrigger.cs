using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;



public class WedgeTrigger : MonoBehaviour
{
    public Transform target;    
    
    public float radius;
    public float height;
    [Range(0,1)]
    public float angThreshold;
    
    void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 up = transform.up;

        Vector3 top = origin + up * height;
        
        Handles.DrawWireDisc(origin,up,radius);
        Handles.DrawWireDisc(top,up,radius);

        float p = angThreshold;
        float x = Mathf.Sqrt(1-p*p);

        Vector3 vLeft = transform.forward * p + transform.right * (-x);
        Vector3 vRight = transform.forward * p + transform.right * x;
        
        
        Gizmos.DrawRay(origin,vRight);
        Gizmos.DrawRay(origin,vLeft);

    }

    
    
}
