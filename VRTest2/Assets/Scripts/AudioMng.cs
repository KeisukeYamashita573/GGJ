using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioInfo
{
    public string key;
    public AudioClip clip;
}

public class AudioMng : MonoBehaviour
{
    [SerializeField]
    private AudioInfo[] _audioInfo;

    private Dictionary<string, AudioClip> _audioDic;

    void Start()
    {
        _audioDic = new Dictionary<string, AudioClip>();
        foreach (var bInfo in _audioInfo)
        {
            _audioDic.Add(bInfo.key, bInfo.clip);
        }
    }

    void Update()
    {
        
    }

    public void PlayBGM(ref string key)
    {
        if (_audioDic.ContainsKey(key))
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.clip = _audioDic[key];
            if (!audio.isPlaying)
            {
               audio.Play();
                Debug.Log("BGMの再生に成功しました。");
            }
            Debug.Log("BGMはすでに再生されています。");
        }
        Debug.Log("BGMの再生に失敗しました。");
    }

    public void PlaySE(ref string key)
    {
        if (_audioDic.ContainsKey(key))
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.clip = _audioDic[key];
            audio.Play();
            Debug.Log("SEの再生に成功しました。");
        }
        Debug.Log("SEの再生に失敗しました。");
    }

    public void StopBGM(ref string key)
    {
       if (_audioDic.ContainsKey(key))
       {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.clip = _audioDic[key];
            if (audio.isPlaying)
            {
                audio.Stop();
                Debug.Log("BGMを停止しました。");
            }
            Debug.Log("BGMは再生されていません。");
       }

        Debug.Log("BGMが見つかりませんでした。");
    }
}
