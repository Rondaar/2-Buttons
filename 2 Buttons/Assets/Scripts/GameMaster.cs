using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    #region singleton
    public static GameMaster instance;

    #endregion
    [SerializeField]
    SinglePlayerController sp;
    [SerializeField]
    MenuController mainMenu;

    int level = 0;
    public float ScreenOffset { get; set; }
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
            if (level%5==0)
            {
                Camera.main.GetComponent<MyAnimation>().StartAnimation();
            }
        }
    }

    public enum GameState { ChoosingGamemode, Playing, GameOver,Restart }
    public GameState currState = GameState.ChoosingGamemode;

    private void Awake()
    {
        instance = this;
        ScreenOffset = 0.025f;
    }

    void Start ()
    {
        ScreenOffset = 0.025f;
        DisplayMenu();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currState == GameState.ChoosingGamemode)
        {
        }else if (currState == GameState.Restart)
        {
            CheckForRestartGame();
        }
	}

    void DisplayMenu()
    {
        mainMenu.DisplayMenu();
    }

    void CheckForRestartGame()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    public event System.Action OnGameOver;
    public event System.Action OnGameBegin;

    public void GameBegin()
    {
        OnGameBegin();
    }

    public void GameOver()
    {
        if (OnGameOver != null) OnGameOver();
        currState = GameState.GameOver;
    }
    public void InitRestart()
    {
        currState = GameState.Restart;
    }

}
