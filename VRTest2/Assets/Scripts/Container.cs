using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    private List<GameObject> _robotList;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public List<GameObject> GetList()
    {
        if(_robotList == null)
        {
            _robotList = new List<GameObject>();
            foreach(Transform child in transform)
            {
                _robotList.Add(child.gameObject);
            }
        }
        return _robotList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
