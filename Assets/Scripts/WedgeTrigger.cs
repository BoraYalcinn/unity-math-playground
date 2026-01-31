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

        Vector3 vLeft = (transform.forward * p + transform.right * (-x)) * radius;
        Vector3 vRight = (transform.forward * p + transform.right * x) * radius;
        
        
        Gizmos.DrawRay(origin,vRight);
        Gizmos.DrawRay(origin,vLeft);
        Gizmos.DrawRay(top,vRight);
        Gizmos.DrawRay(top,vLeft);
        
        Gizmos.DrawLine(top,origin);
        Gizmos.DrawLine(origin + vLeft, top + vLeft);
        Gizmos.DrawLine(origin + vRight, top + vRight);
        
        /*
         *  WE COULD'VE SIMPLIFIED ALL THIS BY:
         *  Gizmos.matrix = transform.localToWorldMatrix;
         *  this would've simplified a lot because now we don't need to write our code
         *  so that the gizmos will follow this line of code will just set the origin to 0
         *  Gizmos.DrawSphere(Vector3.zero,0.1f);
         *
         */
        

    }

    
    
}
