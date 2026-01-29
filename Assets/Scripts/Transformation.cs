using UnityEngine;

public class Transformation : MonoBehaviour
{

    public Vector2 localCoord;
    public Vector2 worldCoord;
    
    
    public void OnDrawGizmos()
    {
        // Local → World 
        Vector2 worldFromLocal = LocalToWorld(localCoord);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(worldFromLocal, 0.1f);

        // World → Local 
        
        Vector2 localFromWorld = WorldToLocal(worldCoord);
        Gizmos.DrawLine(worldCoord,localFromWorld);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(localFromWorld , 0.1f);
        

        // True world reference
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(worldCoord, 0.1f);

        // World origin
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(Vector3.zero, 0.1f);
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
