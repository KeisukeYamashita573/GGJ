using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTime : MonoBehaviour
{
    private Text _text;
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
        _secondTime += Time.deltaTime;
        if(_secondTime >= 60.0f)
        {
            _minuteTime++;
            _secondTime -= 60.0f;
        }
        _text.text = _minuteTime.ToString("00")+ ":" + ((int)_secondTime).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }
}
