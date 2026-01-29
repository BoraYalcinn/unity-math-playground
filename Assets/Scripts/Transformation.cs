using UnityEngine;

public class Transformation : MonoBehaviour
{

    public Vector2 localCoord;
    public Vector2 worldCoord;
    
    
    public void OnDrawGizmos()
    {
        Vector2 worldPos = LocalToWorld(localCoord);
        Gizmos.DrawSphere(worldPos, 0.1f);
        
        Vector2 localPos = WorldToLocal(worldCoord);
        Gizmos.DrawSphere(localPos,0.1f);

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
