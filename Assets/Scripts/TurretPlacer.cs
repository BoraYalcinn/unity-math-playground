using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TurretPlacer : MonoBehaviour
{

    public Transform turret;
    
    void OnDrawGizmos()
    {
        if (turret == null)
            return;
        
        Ray ray = new Ray(
            transform.position,
            transform.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            
            turret.transform.position = hit.point + hit.normal * 0.2050f; // addded offset too fix the half of the objet being inside currently it is hardcoded 
            /*
              turret.rotation = Quaternion.LookRotation(ray.direction);
            */
            
            //  after only adding the above 2 lines our turret will face away from the camera
            // but in some angles it will just look directly down into the ground which is something we
            // don't want . In this case we cann apply cross product with the surface which will give us another
            // vector thats perpendicular.

            
            // the following steps are called gramdt-schmidt method
            Vector3 yAxis = hit.normal;
            Vector3 xAxis = Vector3.Cross(yAxis,ray.direction);
            xAxis = xAxis.normalized; // normalize this so that it always has a spesific length
            
            Vector3 zAxis = Vector3.Cross(xAxis, yAxis); // its direction our turret is looking at

            Gizmos.color = Color.red;
            Gizmos.DrawRay(hit.point, xAxis); // After cross-product
            
            Gizmos.color = Color.green;
            Gizmos.DrawRay(hit.point, yAxis); // it's the normal to the surface 

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(hit.point, zAxis);

            Gizmos.color = Color.white;
            Gizmos.DrawLine(ray.origin,hit.point);

            turret.rotation = Quaternion.LookRotation(zAxis, yAxis); // now our turret is always facing the right direction

        }

    }
    
    
}
