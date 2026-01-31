using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class NewTurretPlacer : MonoBehaviour
{

    public Transform turret;

    void OnDrawGizmos()
    {
        if (turret == null) return;

        Ray ray = new Ray(transform.position,transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            turret.position = hit.point;

            Vector3 yAxis = hit.normal ;
            Vector3 zAxis = Vector3.Cross(transform.right,yAxis).normalized;
            
            // Gizmos.color = Color.red;
            // Gizmos.DrawRay(hit.point, xAxis); // After cross-product
            
            Gizmos.color = Color.green;
            Gizmos.DrawRay(hit.point, yAxis); // it's the normal to the surface 

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(hit.point, zAxis);
            
            Gizmos.color = Color.white;
            Gizmos.DrawLine(ray.origin,hit.point);

            turret.rotation = Quaternion.LookRotation(zAxis,yAxis);

        }

    }



}
