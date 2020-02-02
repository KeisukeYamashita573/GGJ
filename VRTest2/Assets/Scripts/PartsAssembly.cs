using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsAssembly : MonoBehaviour
{
    [SerializeField]
    private GameObject _effect = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Assembly()
    {

    }

    private void Emitter()
    {
        if(_effect.TryGetComponent(out ParticleSystem particle))
        {
            particle.Emit(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("当たり判定が開始された");
        if(other.tag != "Parts")
        {
            Debug.Log("Partsではない");
            return;
        }
        Emitter();
    }
}
