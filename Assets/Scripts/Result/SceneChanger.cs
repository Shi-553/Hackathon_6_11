using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string titleSceneName = "TitleScene";
    public string gameMainSceneName = "GameMainScene";

    public void ToTitle()
    {
        SceneManager.LoadScene(titleSceneName);
    }

    public void ToGameMain()
    {
        SceneManager.LoadScene(gameMainSceneName);
    }
}
