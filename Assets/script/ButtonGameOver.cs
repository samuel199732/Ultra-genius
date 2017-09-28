using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonGameOver : MonoBehaviour {
    private game_loop game;
    [SerializeField]
    private GameObject buttonGameOver;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text bestScore;
    private Vector2 positionStart;
    private Save save;
	// Use this for initialization
    void Start()
    {
        save = GetComponent<Save>();
        bestScore.text = save.getint().ToString();
        game = GetComponent<game_loop>();
        positionStart = score.transform.position;
        
    }
	
	// Update is called once per frame
    void Update ()
    {
	    if(game != null && game.IsGameOver)
        {
            buttonGameOver.SetActive(true);
            score.transform.position = new Vector2( 0,0 );
            if(game.Score > save.getint())
            {
                save.saveScore(game.Score);
                bestScore.text = save.getint().ToString();
            }
        }
        else
        {
            score.transform.position = positionStart;
            buttonGameOver.SetActive(false);
        }
        if (game != null)
            score.text = game.Score.ToString();
     }
}
