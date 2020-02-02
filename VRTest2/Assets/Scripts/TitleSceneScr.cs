using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneScr : MonoBehaviour
{   

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickEndButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        Application.Quit();
#endif
    }
}
