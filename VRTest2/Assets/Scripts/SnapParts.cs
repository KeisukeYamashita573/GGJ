using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapParts : MonoBehaviour
{
    PartsAssembly _assembly;
    void Start()
    {
        _assembly = transform.parent.GetComponent<PartsAssembly>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent(out Rigidbody rigid))
        {
            Debug.LogError("Rigidbodyがアタッチされていません");
            return;
        }
        if(other.tag != "Parts")
        {
            return;
        }
        rigid.useGravity = false;
        rigid.constraints = RigidbodyConstraints.FreezeAll;
        // 座標位置と回転を一致させる
        other.transform.position = this.transform.position - this.transform.forward * 0.1f;
        other.transform.rotation = Quaternion.Euler(-this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180, -transform.eulerAngles.z);
        other.enabled = false;
        _assembly.Emitter();
        _assembly.Assembly(other.gameObject);
        // 自身の当たり判定の無効化
        if (TryGetComponent(out Collider collider))
        {
            collider.enabled = false;
        }
        gameObject.SetActive(false);
    }
}
