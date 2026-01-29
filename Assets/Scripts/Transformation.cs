using UnityEngine;

public class Transformation : MonoBehaviour
{

    public Vector2 localCoord;
    
    public void OnDrawGizmos()
    {
        Vector2 worldPos = LocalToWorld(localCoord);
        
        Gizmos.DrawSphere(localCoord, 0.1f);
        Gizmos.DrawLine(default,worldPos);


    }

    Vector2 LocalToWorld(Vector2 localCoord)
    {
        Vector2 position = transform.position;
        position += localCoord.x * (Vector2) transform.right; // x axis
        position += localCoord.y * (Vector2) transform.up; // y axis
        return position;
    }
    
}
