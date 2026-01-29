using UnityEngine;
using System;
using UnityEngine.PlayerLoop;


public class LaserBounce : MonoBehaviour
{
    public int maxBounces = 10;
    public float maxDistance = 100.0f;

    public void OnDrawGizmos()
    {
        
        Vector2 origin = transform.position;
        Vector2 direction = transform.right; // x axis
        
        Ray ray = new Ray(origin, direction);
        
        Gizmos.DrawLine(origin, origin + direction);
        

        int bounceCount = 0;
        while (bounceCount < maxBounces)
        {
            if (Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance))
            {
                // draw incoming segment
                Gizmos.color = Color.red;
                Gizmos.DrawLine(origin, hit.point);
                Gizmos.DrawSphere(hit.point, 0.05f);

                // reflect
                direction = ReflectVector(hit.normal, direction);

                // move origin slightly forward to avoid self-hit
                origin = hit.point + (Vector3) direction * 0.001f;

                bounceCount++;
            }
            else
            {
                // no hit → draw remaining laser and exit
                Gizmos.DrawLine(origin, origin + direction * maxDistance);
                break;
            }
        }
        
    }

    Vector3 ReflectVector(Vector3 normal, Vector3 direction)
    {
        return direction - 2f * Vector3.Dot(direction, normal) * normal;
    }

    
}
