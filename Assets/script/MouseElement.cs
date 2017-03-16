using UnityEngine;

public class MouseElement : MonoBehaviour {
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject roleta;
            roleta = GameObject.Find("base");
            game_loop game = roleta.GetComponent<game_loop>();
            if (game != null)
                game.playerMove(GetComponent<button>().Id);
        }
    }
}
