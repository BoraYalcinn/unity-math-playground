using UnityEngine;
using System;

public class RadialTrigger : MonoBehaviour
{
    // Radial Trigger Example
    

    public Transform C;
    

    public float radius = 1;
    
    
    void OnDrawGizmos()
    {
        // Radial Trigger
        Vector3 center = transform.position;
        Gizmos.DrawWireSphere(center,radius);
        
        Vector2  c = C.position;
        
        Gizmos.color = Color.green;
        Gizmos.DrawLine(center,c);

        
        
    }
    
}
