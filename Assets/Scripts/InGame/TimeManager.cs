﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    //カウントアップ
    public float countdown = 30.0f;

    //時間を表示するText型の変数
    public Text timeText;
   
    // Start is called before the first frame update
    void Start()
    {
       // countdown = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //時間をカウントする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1") + "秒";

        if (countdown <= 0)
        {
            timeText.text = "時間になりました！";
            SceneManager.LoadScene("Result");
        }

    }
}
