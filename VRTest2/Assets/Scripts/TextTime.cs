using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextTime : MonoBehaviour
{
    private Text _text;
    private float totalTime = 270;
    private float _secondTime;
    private int _minuteTime;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _secondTime = 0.0f;
        _minuteTime = 0;
    }

    private void Timer()
    {
        totalTime -= Time.deltaTime;
        _text.text = (totalTime / 60).ToString("00")+ ":" + (totalTime % 60).ToString("00");
        if (totalTime <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }
}
