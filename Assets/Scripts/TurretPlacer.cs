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
        }

    }
    
    
}
