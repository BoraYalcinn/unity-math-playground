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

        bool isInside = Contains(target.position);
        Color c = isInside ? Color.red : Color.green;
        Gizmos.color = c;
        Handles.color = c;

        // Quaternion up90 = Quaternion.AngleAxis(90, Vector3.up);
        
        Handles.DrawWireDisc(origin, up, radius);
        Handles.DrawWireDisc(top, up, radius);
        

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

    bool Contains(Vector3 position)
    {   
        Vector3 origin = transform.position;   
        Vector3 toPoint = position - origin;
         
        
        // height check
        float h = Vector3.Dot(toPoint, transform.up);
        if (h < 0 || h > height)
            return false;

        // radial check
        Vector3 radial = toPoint - transform.up * h;
        if (radial.sqrMagnitude > radius * radius)
            return false;

        // angular check
        if (radial.sqrMagnitude > 0f)
        {
            float dot = Vector3.Dot(radial.normalized, transform.forward);
            if (dot < angThreshold)
                return false;
        }

        return true;
        
    }
    
    
}
