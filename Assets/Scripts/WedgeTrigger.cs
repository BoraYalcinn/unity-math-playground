using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;



public class WedgeTrigger : MonoBehaviour
{
    public Transform target;    
    
    public float radiusOuter = 2f;
    public float radiusInner = 0.5f;
    public float height = 2f;
    [Range(0,180)]
    public float angle = 90f;
    
    void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 up = transform.up;

        Vector3 top = origin + up * height;

        bool isInside = Contains(target.position);
        Color c = isInside ? Color.red : Color.green;
        Gizmos.color = c;
        Handles.color = c;

        float half = angle * 0.5f;
        
        Vector3 leftDir  = Quaternion.AngleAxis(-half, up) * transform.forward;
        Vector3 rightDir = Quaternion.AngleAxis( half, up) * transform.forward;
        
         DrawConeGizmo();
         /*
          
         // Outer and Inner wedge vectors
         Vector3 vLeftOuter  = leftDir  * radiusOuter;
         Vector3 vRightOuter = rightDir * radiusOuter;

         Vector3 vLeftInner  = leftDir  * radiusInner;
         Vector3 vRightInner = rightDir * radiusInner;

         // edges

         Gizmos.DrawRay(origin, vLeftOuter);
         Gizmos.DrawRay(origin, vRightOuter);
         Gizmos.DrawRay(top, vLeftOuter);
         Gizmos.DrawRay(top, vRightOuter);

         Gizmos.DrawLine(origin + vLeftOuter, top + vLeftOuter);
         Gizmos.DrawLine(origin + vRightOuter, top + vRightOuter);

         Gizmos.DrawRay(origin, vLeftInner);
         Gizmos.DrawRay(origin, vRightInner);
         Gizmos.DrawRay(top, vLeftInner);
         Gizmos.DrawRay(top, vRightInner);

         Gizmos.DrawLine(origin + vLeftInner, top + vLeftInner);
         Gizmos.DrawLine(origin + vRightInner, top + vRightInner);

         // arcs
         Vector3 startDir = leftDir;
         Handles.DrawWireArc(origin, up, startDir, angle, radiusOuter);
         Handles.DrawWireArc(origin, up, startDir, angle, radiusInner);
         Handles.DrawWireArc(top, up, startDir, angle, radiusOuter);
         Handles.DrawWireArc(top, up, startDir, angle, radiusInner);


         /*
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
         */
        
        /*
         *  WE COULD'VE SIMPLIFIED ALL THIS BY:
         *  Gizmos.matrix = transform.localToWorldMatrix;
         *  this would've simplified a lot because now we don't need to write our code
         *  so that the gizmos will follow this line of code will just set the origin to 0
         *  Gizmos.DrawSphere(Vector3.zero,0.1f);
         *
         *
         *    
         *  >   <
         */
        
            

    }

    void DrawConeGizmo()
    {   
        float half = angle * 0.5f;
        
        Vector3 vLeftDir  = Quaternion.AngleAxis(-half, Vector3.up) * Vector3.forward; 
        Vector3 vRightDir = Quaternion.AngleAxis( half, Vector3.up) * Vector3.forward; 
        
        Vector3 vLeftOuter = vLeftDir * radiusOuter;
        Vector3 vRightOuter = vRightDir * radiusOuter;
        Vector3 vLeftInner = vLeftDir * radiusInner;
        Vector3 vRightInner = vRightDir * radiusInner;
        
        
        void SetGizmoMatrix(Matrix4x4 m) => Gizmos.matrix = Handles.matrix = m;
        
        // save
        Matrix4x4 prevMtx = Gizmos.matrix;
        
        //Horizontal
        
        SetGizmoMatrix(transform.localToWorldMatrix); 
        DrawFlatWedge();
        SetGizmoMatrix(prevMtx);
        //Vertical
        SetGizmoMatrix(transform.localToWorldMatrix *Matrix4x4.TRS(default, Quaternion.Euler(0,0,90), Vector3.one));
        DrawFlatWedge();
        SetGizmoMatrix(prevMtx);
        // Up here Freya holmer used a stack implementation of these matrices where you can easily save the matrices by simply pushing and popping although it can be extremly useful I haven't implemented it
        // here in my code since this is a repo mostly about the math behind it all
        
        // so the distance from the center to the circle we are going to draw is distance = r * cos(halfAngle) by basic trigonometry and the
        // diameter of that circle is 2 * r * sin(halfAngle) by again BASIC TRIGONOMETRY (DO I HAVE TO SAY THAT THE RADIUS WILL BE r * sin(halfAngle) ?! )
        
        // rings( the circle I've discussed above )
        SetGizmoMatrix(transform.localToWorldMatrix *Matrix4x4.TRS(default, Quaternion.Euler(0,0,90), Vector3.one));
        DrawRings(radiusOuter);
        DrawRings(radiusInner);
        SetGizmoMatrix(prevMtx);
        
        void DrawRings(float turretRadius)
        {
            float half = angle * 0.5f;
            float halfRad = half * Mathf.Deg2Rad;
            float dist = turretRadius * Mathf.Cos(halfRad);
            float radius = turretRadius * Mathf.Sin(halfRad);

            Vector3 center = new Vector3(0, 0, dist);
            Handles.DrawWireDisc(center,Vector3.forward,radius);
        }
        
        
        void DrawFlatWedge()
        {
            Handles.DrawWireArc(Vector3.zero,Vector3.up,vLeftDir,angle, radiusOuter);
            Handles.DrawWireArc(Vector3.zero,Vector3.up,vLeftDir,angle, radiusInner);
            Gizmos.DrawLine(vLeftInner,vLeftOuter);
            Gizmos.DrawLine(vRightInner,vRightOuter);
        }
        
        
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
        float distSq = radial.sqrMagnitude;

        if (distSq < radiusInner * radiusInner || distSq > radiusOuter * radiusOuter)
            return false;

        // angular check
        if (radial.sqrMagnitude > 0f)
        {
            Vector3 forwardFlat = Vector3.ProjectOnPlane(transform.forward, transform.up).normalized;
            float dot = Vector3.Dot(radial.normalized, forwardFlat);
            float cosHalf = Mathf.Cos((angle * 0.5f) * Mathf.Deg2Rad);
            if (dot < cosHalf)
                return false;
        }

        return true;
        
    }
    
    
}
