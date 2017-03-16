using UnityEngine;
using System.Collections;

public class game_loop : MonoBehaviour {
    [SerializeField]
	private GameObject[] buttons; //vetor das peças
	private double timeLimit0 = 1.0f; //timer para tocar o som de uma peça
	private double timeLimit = 1.5f; //timer para tocar todos os sons da máquina
	private bool isPlaying; //se a peça está tocando

	private ArrayList sounds; //jogadas da máquina
	private ArrayList playerSounds; //jogadas do player

	private int cont; // posição ao tocar todos os sons
	private bool isPlayingAll; // se todas as peças estão tocando

	private int score = 0;
    private bool isGameOver = false;
    // Use this for initialization
    void Start ()
    {
		initGame ();
	}
	// Update is called once per frame
	void Update ()
    {

		if (!isPlaying && !isPlayingAll && !IsGameOver)
        {
			if (Input.GetKeyDown (KeyCode.W))
            {
                //VERMELHO
				playerMove(0);
			}
            else 
            if (Input.GetKeyDown (KeyCode.S))
            {
                //AZUL
				playerMove(1);
			}
            else 
            if (Input.GetKeyDown (KeyCode.A))
            {
                //AMARELO
				playerMove(2);
			}
            else 
            if (Input.GetKeyDown (KeyCode.Q))
            {
                //VERDE
				playerMove(3);
			}
		}
		if (IsGameOver)
        {
			if (Input.GetKeyDown (KeyCode.Space)) {
				initGame ();
			}
		}
		// Se um som está tocando
		if (isPlaying)
        {
			timeLimit0 -= Time.deltaTime;
			if(timeLimit0 <= 0)
            {
				resetColors ();
				isPlaying = false;
			}
		}
		//Se todos estão tocando
		if (isPlayingAll)
        {
			if (cont == sounds.Count)
				isPlayingAll = false;
			
			timeLimit -= Time.deltaTime;
			if (timeLimit <= 0)
            {
				playSound ( (int)sounds[cont]   );
				timeLimit = 1.5f;
				cont++;
			}
		}

	}
	public void playerMove(int p)
    {
		if (!isPlayingAll && !isPlaying && !IsGameOver)
        {
			playerSounds.Add (p);
			if (p != (int)sounds [playerSounds.Count - 1])
            {
				IsGameOver = true;
			}
            else 
            if( playerSounds.Count == sounds.Count )
            {
				Score++;
				playerSounds = new ArrayList ();
				sounds.Add ( (int)Random.Range(0,4) );
				playAll ();
			}
            playSound(p);
        }
	}
	void playSound(int pos)
    {
		if (pos >= 0 && pos < 4 && !isGameOver)
        {
			timeLimit0 = 1.0f;
			GameObject but = buttons [pos];
			AudioSource audio = but.GetComponent<AudioSource> ();
			if (!audio.isPlaying)
            {
				audio.Play ();
				setAlpha (buttons [pos], 1.0f);
			}
			isPlaying = true;
		}
        else
        {
            AudioSource audio = GetComponent<AudioSource>();
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            }
	}
	void setAlpha(GameObject go, float value)
    {
		Color color = go.GetComponent<Renderer> ().material.color;
		color.a = value;
		go.GetComponent<Renderer> ().material.color = color;
	}
	void resetColors()
    {
		for (int i = 0; i < buttons.Length; i++)
        {
			setAlpha (buttons [i], 0.2f);
		}
	}
	public void initGame()
    {
		isPlaying = false;
		isPlayingAll = false;
		IsGameOver = false;
		resetColors ();
		sounds = new ArrayList ();
		playerSounds = new ArrayList ();
		Score = 0;
		sounds.Add ( (int)Random.Range(0,4) );
		playAll ();
	}
	void playAll()
    {
		cont = 0;
		isPlayingAll = true;
	}
    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }

        set
        {
            isGameOver = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

}
