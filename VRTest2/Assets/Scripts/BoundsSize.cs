using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsSize : MonoBehaviour
{
    public enum BODY_TYPE
    {
        HEAD,
        ARM_L,
        ARM_R,
        REG_L,
        REG_R,
        BODY,
        MAX
    }
    public BODY_TYPE _type;
    private Renderer _renderer;
    private Vector3 _size;
    public Vector3 Size
    {
        get { return _size; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _type = BODY_TYPE.MAX;
        foreach (Transform child in transform)
        {
            _renderer = child.GetComponent<Renderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_renderer == null)
        {
            return;
        }
        _size = _renderer.bounds.size;
    }
}