using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsSize : MonoBehaviour
{
    private Renderer _renderer;
    private Vector3 _size;
    public Vector3 Size
    {
        get { return _size; }
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            _renderer = GetComponent<Renderer>();
        }
    }



    // Update is called once per frame
    void Update()
    {
        if(_renderer == null)
        {
            return;
        }
        _size = _renderer.bounds.size;
    }
}
