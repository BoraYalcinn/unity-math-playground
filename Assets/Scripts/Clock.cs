using UnityEditor;
using UnityEngine;

public class Clock : MonoBehaviour
{
    
    [Range(0,60)]
    public float secondsTest;
    
    [Range(0,0.2f)]
    public float tickSizeSecMin = 0.05f;
    [Range(0,0.2f)]
    public float tickSizeHours = 0.05f;
    
    public const float radius = 1;
    
    void OnDrawGizmos()
    {
        Handles.matrix = Gizmos.matrix = transform.localToWorldMatrix;
        Handles.DrawWireDisc(default,Vector3.forward, radius );
        
        // ticks (minutees/seconds)
        for (int i = 0; i < 60; i++)
        {
            Vector2 dir = SecondsOrMinutesToDirection(i);
            DrawTick(dir,tickSizeSecMin,1);
        }
        // ticks (hours)
        for (int i = 0; i < 12; i++)
        {
            Vector2 dir = HoursToDirection(i);
            DrawTick(dir,tickSizeHours,3);
        }
        
        Gizmos.DrawRay(default,radius * SecondsOrMinutesToDirection(secondsTest));
    }
    
    Vector2 AngToDir(float angleRad) => new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

    void DrawTick(Vector2 dir, float length, float thickness)
    {
        Handles.DrawLine(dir,dir * (1f - length),thickness);
        
    }
    
    Vector2 HoursToDirection(float hours) => ValueToDirection(hours, 12);
    
    Vector2 SecondsOrMinutesToDirection(float secOrMin)
    {
        return ValueToDirection(secOrMin,60);
        
        // float t = secOrMin / 60; // percent along the 0-60 range (1-0 representation)
        // return FractionToClockDir(t);
    }

    Vector2 ValueToDirection(float value, float valueMax)
    {
        float t = value / valueMax; // percent along the 0-60 range (1-0 representation)
        return FractionToClockDir(t);
    }
    
    
    Vector2 FractionToClockDir(float t)
    {
        float angleRad = (0.25f - t) * Mathf.PI * 2;
        return AngToDir(angleRad);
    }
    
}
