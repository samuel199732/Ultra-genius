using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {
    int best_score;
    // Use this for initialization
    void Start()
    {
        best_score = getint();
    }
    public int getint()
    {
        return PlayerPrefs.GetInt("best", 0);
    }
    public void saveScore(int score)
    {
        PlayerPrefs.SetInt("best", score);
    }
}
