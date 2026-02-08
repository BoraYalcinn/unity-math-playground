using UnityEngine;

public class LerpTest : MonoBehaviour
{
    [Range(0f, 1f)] public float t = 0;
    public Transform aTf;
    public Transform bTf;

    void OnDrawGizmos()
    {
        Vector3 a = aTf.position;
        Vector3 b = bTf.position;
        
        Gizmos.DrawLine(a,b);

        Vector3 pos = Vector3.Lerp(a, b, t);
        
        Gizmos.DrawSphere(pos,0.05f);
        
    }


}
