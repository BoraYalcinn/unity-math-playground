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
            turret.transform.position = hit.point;
            turret.rotation = Quaternion.LookRotation(ray.direction);
            //  after only adding the above 2 lines our turret will face away from the camera
            // but in some angles it will just look directly down into the ground which is something we
            // don't want . In this case we cann apply cross product with the surface which will give us another
            // vector thats perpendicular.
        }

    }
    
    
}
