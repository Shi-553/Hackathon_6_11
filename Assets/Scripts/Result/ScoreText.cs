using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    public int speed = 10;
    private Text text;
    private int value = 0;
    private int target = 0;

    void Start()
    {
        text = GetComponent<Text>();
        target = ScoreManager.Get();
        ChangeScoreText();
    }

    void Update()
    {
        if (value >= target) return;
        value += speed;
        if (value > target) value = target;
        ChangeScoreText();
    }

    void ChangeScoreText()
    {
        if (!text) return;
        text.text = value.ToString();
    }
}
