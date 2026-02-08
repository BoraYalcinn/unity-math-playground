using UnityEngine;

public class LerpTest : MonoBehaviour
{
    [Range(0f, 1f)] public float t = 0;
    public Transform aTf;
    public Transform bTf;
    
    public Transform cTf;
    public Transform dTf;
    
    public Color colorA;
    public Color colorB;
    
    void OnDrawGizmos()
    {
        Vector3 a = aTf.position;
        Vector3 b = bTf.position;
        
        Vector3 c = cTf.position;
        Vector3 d = dTf.position;
        
        Gizmos.DrawLine(a,b);

        Vector3 pos = Vector3.Lerp(a, b, t);
        Gizmos.color = Color.Lerp(colorA, colorB, t);
        Gizmos.DrawSphere(pos,0.05f);
        
        
        Gizmos.DrawLine(a,b);
        Gizmos.DrawLine(b,c);
        Gizmos.DrawLine(c,d);
        
        Gizmos.DrawSphere(GetBezierPt(a,b,c,d,t),0.05f);
    }

    Vector3 GetBezierPt(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 a = Vector3.Lerp(p0, p1, t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        Vector3 c = Vector3.Lerp(p2, p3, t);
        
        Vector3 d = Vector3.Lerp(a, b, t);
        Vector3 e = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(d,e,t);

    }


}
