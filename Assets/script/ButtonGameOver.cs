using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonGameOver : MonoBehaviour {
    private game_loop game;
    [SerializeField]
    private GameObject buttonGameOver;
    [SerializeField]
    private Text score;
    private Vector2 positionStart;
	// Use this for initialization
	void Start()
    {
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
