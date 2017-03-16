using UnityEngine;
using System.Collections;

public class TouchElement : MonoBehaviour {
    private RaycastHit hit;
    private Ray ray;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
       if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject roleta;
                roleta = GameObject.Find("base");
                game_loop game = roleta.GetComponent<game_loop>();
                if (game != null)
                    game.playerMove(hit.collider.GetComponent<button>().Id);
            }
        }
    }
}
