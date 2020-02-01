using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGizmos : MonoBehaviour
{
    [SerializeField]
    private PrimitiveType _type = PrimitiveType.Cube;
    [SerializeField]
    private Color _color = Color.white;
    [SerializeField, Header("Debug")]
    private bool _active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if(!_active)
        {
            return;
        }

        Gizmos.color = _color;
        Gizmos.matrix = transform.localToWorldMatrix;

        Vector3 offset = Vector3.zero;
        Vector3 size = Vector3.one;
        float radius = 0.5f;
        // 当たり判定の大きさと合わせる
        if(TryGetComponent(out BoxCollider box))
        {
            offset = box.center;
            size = box.size;
        }
        if(TryGetComponent(out SphereCollider sphere))
        {
            radius = sphere.radius;
        }
        switch (_type)
        {
            case PrimitiveType.Sphere:
                Gizmos.DrawSphere(Vector3.zero, radius);
                break;
            case PrimitiveType.Capsule:
                break;
            case PrimitiveType.Cylinder:
                break;
            case PrimitiveType.Cube:
                Gizmos.DrawCube(Vector3.zero + offset, size);
                break;
            case PrimitiveType.Plane:
                break;
            case PrimitiveType.Quad:
                break;
            default:
                break;
        }
    }
}