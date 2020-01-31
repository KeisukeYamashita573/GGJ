using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapParts : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigid = other.GetComponent<Rigidbody>();
        if(rigid == null)
        {
            Debug.LogError("Rigidbodyがアタッチされていません");
            return;
        }
        rigid.useGravity = false;
        rigid.constraints = RigidbodyConstraints.FreezeAll;
        other.transform.position = this.transform.position;
        other.transform.rotation = this.transform.rotation;
        other.GetComponent<Collider>().enabled = false;
    }
}
