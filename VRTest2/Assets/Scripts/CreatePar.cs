using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePar : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabList = new GameObject[0];
    [SerializeField, Tooltip("1つ当たりの生成上限数")]
    private int _count; 

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
