using UnityEngine;
using System;
using UnityEngine.PlayerLoop;


public class LaserBounce : MonoBehaviour
{


    public void OnDrawGizmos()
    {
        
        Vector2 origin = transform.position;
        Vector2 direction = transform.right; // x axis
        
        Ray ray = new Ray(origin, direction);
        
        Gizmos.DrawLine(origin, origin + direction);

        if (Physics.Raycast(ray,out RaycastHit hit))
        {
            Gizmos.DrawSphere(hit.point,0.1f);
        }
        
        
    }
}
