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
            // Vector2 reflection = direction + (hit.normal * (-2) * Vector2.Dot(direction, hit.normal));  ***formula for the reflection***
            // writing a seperate function for calculating the reflection vector will be much more useful 
            Vector2 reflection = ReflectVector(hit.normal,ray.direction);
            // there is also a built-in reflect function also but I will not be using it
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(hit.point, (Vector2) hit.point + reflection);
        }
        
    }

    Vector2 ReflectVector(Vector2 normal, Vector2 direction)
    {
        return direction + (normal * (-2) * Vector2.Dot(direction, normal));
    }
    
}
