using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultModel : MonoBehaviour
{
    private float time;

    [SerializeField]
    GameObject[] robots;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        for(int i = 0; i<robots.Length;++i)
        {
            robots[i].SetActive(false);
            robots[i] =Instantiate(robots[i], new Vector3(-6 + i * 3, 6.3f, 10), new Quaternion());
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < robots.Length; ++i)
        {
            if ((time / ((i+1)*3)) >= 1)
            {
                robots[i].SetActive(true);
            }
        }

        time += Time.deltaTime;
    }
}
