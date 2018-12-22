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
    GameObject[] buttonsOnStart;
    [SerializeField]
    GameObject leftOption;
    [SerializeField]
    GameObject rightOption;
    [SerializeField]
    SinglePlayerController sp;
    [SerializeField]
    MultiPlayerController mp;

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
        //leftOption.GetComponent<SlideInAnimation>().StartAnimation();
        //rightOption.GetComponent<SlideInAnimation>().StartAnimation();
        foreach(GameObject button in buttonsOnStart)
        {
            button.GetComponent<SlideInAnimation>().StartAnimation();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currState == GameState.ChoosingGamemode)
        {
           // ChooseGameMode();
        }else if (currState == GameState.Restart)
        {
            CheckForRestartGame();
        }
	}
    
    void CheckForRestartGame()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void ChooseGameMode()
    {
        if (Input.touchCount>0||Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            leftOption.GetComponent<ChooseAnimation>().StartAnimation();
            sp.GetComponent<Option>().Action();
            rightOption.GetComponent<FadeAnimation>().StartAnimation();  
            Destroy(mp.gameObject);
            currState = GameState.Playing;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightOption.GetComponent<ChooseAnimation>().StartAnimation();
            mp.GetComponent<Option>().Action();
            leftOption.GetComponent<FadeAnimation>().StartAnimation();
            Destroy(sp.gameObject);
            currState = GameState.Playing;
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
