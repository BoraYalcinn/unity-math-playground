using UnityEngine;
using System.Collections;

public class TriangleTesting : MonoBehaviour
{
    public Transform aTf;
    public Transform bTf;
    public Transform cTf;
    public Transform pTf;
    
    void OnDrawGizmos()
    {
        Vector2 a = aTf.position;
        Vector2 b = bTf.position;
        Vector2 c = cTf.position;
        Vector2 pt = pTf.position;
        
        Gizmos.color = TriangleContains(a,b,c,pt) ?  Color.green : Color.red;
        Gizmos.DrawLine(a,b);
        Gizmos.DrawLine(b,c);
        Gizmos.DrawLine(c,a);
        Gizmos.DrawSphere(pt,0.02f);
    }

    // wedge product/determinant/perp. dot product/ "2D cross product" it has many names :)
    public float Wedge(Vector2 a, Vector2 b)
    {
        return a.x * b.y - a.y * b.x ;
    }
    
    // we can think of it like a Venn Diagram
    public bool TriangleContains(Vector2 a, Vector2 b, Vector2 c,Vector2 pt)
    {

        bool ab = GetSideSign(a, b, pt);
        bool bc = GetSideSign(b, c, pt);
        bool ca = GetSideSign(c, a, pt);

        return ab == bc && bc == ca;

    }

    bool GetSideSign(Vector2 a, Vector2 b, Vector2 p)
    {
        Vector2 sideVec = b - a;
        Vector2 ptRel = p - a;
        return Wedge(sideVec, ptRel) > 0;
    }
    
    
}
