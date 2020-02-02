using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsAssembly : MonoBehaviour
{
    [SerializeField]
    private GameObject _effect = null;
    private GameObject _robot;
    private int _repairCount;
    [SerializeField]
    private int _repairNum = 6;
    [SerializeField]
    private GameObject _container;
    private BoundsSize _body;
    // Start is called before the first frame update
    void Start()
    {
        _robot = new GameObject();
        _robot.transform.parent = gameObject.transform;
        _robot.transform.position = transform.position;
        _robot.transform.rotation = Quaternion.Euler(-transform.eulerAngles.x, 180, 0);
        _robot.name = "robot";
        _repairCount = 0;
    }

    private void OnDestroy()
    {
        SetPoint();
        if (_robot == null || _container == null) return;
        _robot.transform.parent = _container.transform;
    }

    private void SetPoint()
    {
        if (_robot == null) return;
        _robot.transform.rotation = Quaternion.Euler(0, 0, 0);
        foreach (Transform child in _robot.transform)
        {
            if (child.TryGetComponent(out BoundsSize bounds))
            {
                switch (bounds._type)
                {
                    case BoundsSize.BODY_TYPE.HEAD:
                        bounds.transform.localPosition = new Vector3(0, _body.Size.y / 2 + bounds.Size.y / 2 - 0.5f, 0);
                        break;
                    case BoundsSize.BODY_TYPE.ARM_L:
                        bounds.transform.localPosition = new Vector3(_body.Size.x / 2 + bounds.Size.x / 2 - 0.2f, 0, 0);
                        break;
                    case BoundsSize.BODY_TYPE.ARM_R:
                        bounds.transform.localPosition = new Vector3(-_body.Size.x / 2 - bounds.Size.x / 2 + 0.2f, 0, 0);
                        break;
                    case BoundsSize.BODY_TYPE.REG_L:
                        bounds.transform.localPosition = new Vector3(0.1f, -_body.Size.y / 2 - bounds.Size.y / 2 + 0.1f, 0);
                        break;
                    case BoundsSize.BODY_TYPE.REG_R:
                        bounds.transform.localPosition = new Vector3(-0.1f, -_body.Size.y / 2 - bounds.Size.y / 2 + 0.1f, 0);
                        break;
                    case BoundsSize.BODY_TYPE.BODY:
                        bounds.transform.localPosition = new Vector3(0, 0, 0);
                        Debug.LogError("入りすぎ");
                        break;
                    case BoundsSize.BODY_TYPE.MAX:
                    default:
                        break;
                }
            }
        }
    }
    public void Assembly(GameObject obj)
    {
        obj.transform.parent = _robot.transform;
        if (obj.TryGetComponent(out BoundsSize bounds))
        {
            if (bounds._type == BoundsSize.BODY_TYPE.BODY)
            {
                _body = bounds;
            }
        }
        _repairCount++;
        if(_repairCount >= _repairNum)
        {

        }
    }

    public void Emitter()
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

    public int GetRepairCount {
        get { return _repairCount;}
    }
}