using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapParts : MonoBehaviour
{
    [SerializeField]
    private BoundsSize.BODY_TYPE _type;
    PartsAssembly _assembly;
    [SerializeField]
    private Vector3 _offset = Vector3.zero;
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
        if(other.TryGetComponent(out BoundsSize bounds))
        {
            bounds._type = _type;
        }

        _assembly.Emitter();
        _assembly.Assembly(other.gameObject);
        other.transform.localPosition += _offset;
        // 自身の当たり判定の無効化
        if (TryGetComponent(out Collider collider))
        {
            collider.enabled = false;
        }
        gameObject.SetActive(false);
    }
}
