using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneScr : MonoBehaviour
{
    public void OnClickReStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
