using UnityEngine;
using System;

public class LessonOne : MonoBehaviour
{
    public Transform A;
    public Transform B;

    public float scProj;

    void OnDrawGizmos()
    {
        if (A == null || B == null)
        {
            return;
        }

        Vector2 a = A.position;
        Vector2 b = B.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(default,a);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(default,b);
        
        // Normalization
        float aLen = Mathf.Sqrt(a.x * a.x + a.y * a.y);
        float bLen = Mathf.Sqrt(b.x * b.x + b.y * b.y);
        Vector2 NormalizedA = a / aLen;
        Vector2 NormalizedB = b/bLen;
        
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(NormalizedA, 0.05f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(NormalizedB, 0.05f);
        
        // Scalar Projection

    }
    
    
}
