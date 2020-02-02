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
        _robot.transform.parent = _container.transform;
    }

    public void Assembly(GameObject obj)
    {
        obj.transform.parent = _robot.transform;
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
}
