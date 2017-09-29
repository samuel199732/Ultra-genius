using UnityEngine;

public class Save : MonoBehaviour {
    public int getint()
    {
        return PlayerPrefs.GetInt("best", 0);
    }
    public void saveScore(int score)
    {
        PlayerPrefs.SetInt("best", score);
    }
}
