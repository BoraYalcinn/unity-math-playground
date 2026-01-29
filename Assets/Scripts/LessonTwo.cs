using UnityEngine;
using System;

public class LessonTwo : MonoBehaviour
{
    public Vector2 localCoord;
    public Vector2 worldCoord;
    
    
    public void OnDrawGizmos()
    {
        
        Matrix4x4 localToWorldMtx = transform.localToWorldMatrix;
        
        // Transforming between local and world
        // transform.TransformPoint()         // M*(v.x,v.y,v.z,1)
        // transform.InverseTransformPoint()  // M^1*(v.x,v.y,v.z,1)
        // transform.TransformVector()        // M*(v.x,v.y,v.z,0)
        // transform.InverseTransformVector() // M^1*(v.x,v.y,v.z,0)

    }
    

    Vector2 WorldToLocal(Vector2 worldPos)
    {
        Vector2 rel = worldPos - (Vector2)transform.position;
        float x = Vector2.Dot(rel, transform.right); // x axis
        float y = Vector2.Dot(rel, transform.up); // y axis
        return new(x,y);
    }
    
    Vector2 LocalToWorld(Vector2 localCoord)
    {
        Vector2 position = transform.position;
        position += localCoord.x * (Vector2) transform.right; // x axis
        position += localCoord.y * (Vector2) transform.up; // y axis
        return position;
    }
    
    
}
