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
        other.GetComponent<Rigidbody>().useGravity = false;
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        other.transform.position = this.transform.position;
        other.transform.rotation = Quaternion.Euler(30,0,0);
    }
}
