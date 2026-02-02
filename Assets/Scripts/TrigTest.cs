using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.Rendering;

public class TrigTest : MonoBehaviour
{

    [Range(0, 360)] 
    public float angDeg =  0;
    
    void OnDrawGizmos()
    {

        Handles.DrawWireDisc(Vector3.zero,Vector3.forward,1);
        
        float angRad =  angDeg * Mathf.Deg2Rad;

        float angTurns = (float)EditorApplication.timeSinceStartup;
        Vector2 v = AngToDir(angRad);
        // Vector2 v = AngToDir(angTurns*Mathf.PI *2 ); //  1 turn per second ! 
        Gizmos.DrawRay(default,v);
        
    }

    static Vector2 AngToDir(float angRad)
    {
        return new Vector2(Mathf.Cos(angRad),Mathf.Sin(angRad));
    }
    
}
