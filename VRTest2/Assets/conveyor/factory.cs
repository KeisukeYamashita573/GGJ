using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factory : MonoBehaviour
{
    //[SerializeField] 
    //GameObject[] obj;
    [SerializeField]
    int popTime;        // 出現間隔

    private float count;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        time += Time.deltaTime;
        var mat = GetComponent<Renderer>().material;
        mat.SetFloat("_Timehq", time/10);

        if (count > popTime)
        {
            count = 0;
            GetComponent<CreateParts>().SetParts().transform.position = this.transform.position + new Vector3(7, 2, 0);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        collision.transform.position -= new Vector3(Time.deltaTime, 0, 0);
    }
}
