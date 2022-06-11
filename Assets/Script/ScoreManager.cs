using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    static int score = 0;

    // リセット
    public static void Reset()
    {
        score= 0;
    }
    // スコア追加か減点
    public static void Add(int added)
    {
        score += added;
    }
    // スコア取得
    public static int Get()
    {
        return score;
    }
}
