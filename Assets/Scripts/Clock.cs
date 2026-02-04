using UnityEditor;
using UnityEngine;

public class Clock : MonoBehaviour
{
    
    [Range(0,60)]
    public float secondsTest;

    public float radius = 1;
    
    void OnDrawGizmos()
    {
        Handles.matrix = Gizmos.matrix = transform.localToWorldMatrix;
        Handles.DrawWireDisc(default,Vector3.forward, radius );

        Gizmos.DrawRay(default,radius * SecondsToDirection(secondsTest));
    }
    
    Vector2 AngToDir(float angleRad) => new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    
    Vector3 SecondsToDirection(float seconds)
    {
        float t = seconds / 60; // percent along the 0-60 range (1-0 representation)
        float angleRad =  t * Mathf.PI * 2;
        return AngToDir(angleRad);
    }
    
}
